import sys
import hashlib

def print_help():
    print("Usage: md5sum [options] [file]")
    print("Options:")
    print("  -b    Use binary mode")
    print("  -t    Use text mode (default)")
    print("  -h    Show this help")

def main():
    args = sys.argv[1:]
    
    if any(arg in ('-h', '--help', '/?') for arg in args):
        print_help()
        return 0
    
    binary_mode = '-b' in args
    text_mode = '-t' in args
    
    files = [arg for arg in args if not arg.startswith('-')]
    
    if not files:
        # Read from stdin
        data = sys.stdin.buffer.read() if binary_mode else sys.stdin.read()
        md5 = hashlib.md5(data).hexdigest()
        print(f"{md5}  -")
        return 0
    
    for file_path in files:
        try:
            mode = 'rb' if binary_mode else 'r'
            with open(file_path, mode) as f:
                data = f.read()
            md5 = hashlib.md5(data).hexdigest()
            print(f"{md5}  {file_path}")
        except FileNotFoundError:
            print(f"Error: File '{file_path}' not found")
        except Exception as e:
            print(f"Error: {e}")
    
    return 0

if __name__ == "__main__":
    sys.exit(main())