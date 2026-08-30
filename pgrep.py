import subprocess
import sys
import re
import platform

def print_help():
    print("Usage: pgrep [options] name...")
    print("Options:")
    print("  -f    Match full command line")
    print("  -a    Show command name only")
    print("  -l    Long format")
    print("  -h    Show this help")

def main():
    args = sys.argv[1:]
    
    if '-h' in args or '--help' in args:
        print_help()
        return 0
    
    names = [arg for arg in args if not arg.startswith('-')]
    
    if not names:
        print("Error: Please provide at least one process name to search")
        return 1
    
    try:
        result = subprocess.run(['tasklist'], capture_output=True, text=True, check=True)
        lines = result.stdout.strip().split('\n')
        found = []
        
        for line in lines[3:]:
            if not line.strip():
                continue
            parts = line.split()
            if len(parts) >= 2:
                pid = parts[1]
                cmd_parts = parts[0].split('.exe')
                cmd_name = cmd_parts[0] if cmd_parts else parts[0]
                
                for name in names:
                    if name.lower() in cmd_name.lower() or name.lower() in line.lower():
                        found.append((pid, line))
        
        if not found:
            return 1
        
        for pid, line in found:
            print(f"{pid}:{line.split()[0]}")
        
        return 0
    except subprocess.CalledProcessError as e:
        print(f"Error: {e}")
        return 1
    except Exception as e:
        print(f"Error: {e}")
        return 1

if __name__ == "__main__":
    sys.exit(main())