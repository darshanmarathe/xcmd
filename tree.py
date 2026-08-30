import os
import sys
from pathlib import Path

def print_help():
    print("Usage: tree [options] [directory]")
    print("Options:")
    print("  -a    Show all files (including hidden)")
    print("  -L    Limit depth")
    print("  -h    Show this help")

def tree(directory, prefix="", is_last=True, show_hidden=False, max_depth=None, current_depth=0):
    if max_depth is not None and current_depth >= max_depth:
        return
    
    try:
        entries = sorted(os.listdir(directory))
        
        if not show_hidden:
            entries = [e for e in entries if not e.startswith('.')]
        
        for i, entry in enumerate(entries):
            path = os.path.join(directory, entry)
            is_entry_last = (i == len(entries) - 1)
            
            if os.path.isdir(path):
                print(f"{prefix}{'└── ' if is_last else '├── '}{entry}/")
                new_prefix = prefix + ('    ' if is_last else '│   ')
                tree(path, new_prefix, is_entry_last, show_hidden, max_depth, current_depth + 1)
            else:
                print(f"{prefix}{'└── ' if is_last else '├── '}{entry}")
    except PermissionError:
        print(f"{prefix}{'└── ' if is_last else '├── '}[Permission denied]")

def main():
    args = sys.argv[1:]
    
    if not args:
        tree('.')
        return 0
    
    show_hidden = False
    max_depth = None
    directory = '.'
    
    i = 0
    while i < len(args):
        arg = args[i]
        if arg == '-a':
            show_hidden = True
        elif arg == '-L' and i + 1 < len(args):
            try:
                max_depth = int(args[i + 1])
                i += 1
            except ValueError:
                print(f"Error: Invalid depth value: {args[i + 1]}")
                return 1
        elif arg in ('-h', '--help', '/?'):
            print_help()
            return 0
        elif not arg.startswith('-'):
            directory = arg
        i += 1
    
    if not os.path.isdir(directory):
        print(f"Error: '{directory}' is not a directory")
        return 1
    
    tree(directory, '', True, show_hidden, max_depth)
    
    return 0

if __name__ == "__main__":
    sys.exit(main())