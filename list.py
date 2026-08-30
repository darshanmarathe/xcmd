import os
import sys
from datetime import datetime

green = '\033[92m'
reset = '\033[0m'

def print_help():
    print("Usage: ls [options] [path]")
    print("Options:")
    print("  -l    Long format (detailed listing)")
    print("  -c    Copy output to clipboard")
    print("  -h    Show this help")

def print_green(text):
    print(f"{green}{text}{reset}")

def print_file_details(file_path):
    try:
        stats = os.stat(file_path)
        mod_time = datetime.fromtimestamp(stats.st_mtime)
        date_only = mod_time.strftime("%d-%b-%Y")
        date_time = mod_time.strftime("%d-%b-%Y %H:%M:%S")
        size = stats.st_size
        _, ext = os.path.splitext(file_path)
        if not ext:
            ext = "(no extension)"
        file_name = os.path.basename(file_path)
        print(f"{date_only}  {date_time}  {size}  {ext}  {file_name}")
    except Exception as e:
        print(f"Error getting file details: {e}")

def list_directory(path):
    try:
        if not os.path.isdir(path):
            print(f"Error: '{path}' is not a directory")
            return 1
        contents = os.listdir(path)
        for item in contents:
            full_path = os.path.join(path, item)
            if os.path.isdir(full_path):
                print_green(item)
        print()
        for item in contents:
            full_path = os.path.join(path, item)
            if os.path.isfile(full_path):
                print_file_details(full_path)
    except Exception as e:
        print(f"Error: {e}")
        return 1
    finally:
        print("")
    return 0

def main():
    args = sys.argv[1:]
    
    if any(arg in ('-h', '--help') for arg in args):
        print_help()
        return 0
    
    path = args[0] if args and not args[0].startswith('-') else os.getcwd()
    is_list = '-l' in args
    
    print(f"Reading Folder: {path} with python")
    return list_directory(path)

if __name__ == "__main__":
    sys.exit(main())