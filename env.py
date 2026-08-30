import os
import sys

def print_help():
    print("Usage: env [options]")
    print("Options:")
    print("  -h    Show this help")
    print("")
    print("Display environment variables.")

def main():
    args = sys.argv[1:]
    
    if any(arg in ('-h', '--help', '/?') for arg in args):
        print_help()
        return 0
    
    env_vars = os.environ
    
    # Sort environment variables alphabetically
    for key in sorted(env_vars.keys()):
        print(f"{key}={env_vars[key]}")
    
    return 0

if __name__ == "__main__":
    sys.exit(main())