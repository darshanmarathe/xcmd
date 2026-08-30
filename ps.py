"""
List currently running processes.

Usage: ps [options]
  -a    Show all processes with full command line
  -f    Full format listing
"""
import sys
import subprocess
import platform

def print_help():
    print("Usage: ps [options]")
    print("Options:")
    print("  -a    Show all processes with full command line")
    print("  -f    Full format listing")
    print("  -h    Show this help")

def main():
    args = sys.argv[1:]
    
    if any(arg in ('-h', '--help', '/?') for arg in args):
        print_help()
        return 0
    
    show_all = '-a' in args or '-f' in args
    
    try:
        if platform.system() == 'Windows':
            cmd = ['tasklist']
            if show_all:
                cmd.append('/V')
            
            result = subprocess.run(cmd, capture_output=True, text=True, check=True)
            lines = result.stdout.strip().split('\n')
            
            if not show_all:
                for line in lines[:20]:
                    print(line)
                if len(lines) > 20:
                    print(f"\n... and {len(lines) - 20} more processes (use -a to see all)")
            else:
                for line in lines:
                    print(line)
        else:
            cmd = ['ps']
            if show_all:
                cmd.append('-ef')
            else:
                cmd.append('-e')
            subprocess.run(cmd, check=True)
    except subprocess.CalledProcessError as e:
        print(f"Error listing processes: {e}")
        return 1
    except FileNotFoundError:
        print("Error: 'tasklist' command not found")
        return 1
    
    return 0

if __name__ == "__main__":
    sys.exit(main())