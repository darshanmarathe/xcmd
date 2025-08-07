import os
import sys
from datetime import datetime

green = '\033[92m'  # ANSI escape code for green
reset = '\033[0m'  # ANSI escape code to reset color

folderPath = sys.argv[1]
args = sys.argv[1:]

is_list = '-l' in args

print(f"Reading Folder: {folderPath} with python")


def print_green(text):
    print(f"{green}{text}{reset}")


def print_file_details(file_path):
    try:
        # Get file stats
        stats = os.stat(file_path)

        # Get modification time
        mod_time = datetime.fromtimestamp(stats.st_mtime)
        date_only = mod_time.strftime("%d-%b-%Y")
        date_time = mod_time.strftime("%d-%b-%Y %H:%M:%S")

        # Get file size
        size = stats.st_size

        # Get file extension
        _, ext = os.path.splitext(file_path)
        if not ext:
            ext = "(no extension)"

        # Get file name
        file_name = os.path.basename(file_path)

        # Print in the specified format
        print(f"{date_only}  {date_time}  {size}  {ext}  {file_name}")

    except Exception as e:
        print(f"Error getting file details: {e}")


def list_directory(path):
    try:
        contents = os.listdir(path)
        for item in contents:
            full_path = os.path.join(path, item)
            if os.path.isdir(full_path):
               if is_list:
                   print_green(item)
               else:
                   print(f'{green}{item}')
        print('\n' + reset)
        for item in contents:
            full_path = os.path.join(path, item)
            if os.path.isfile(full_path):
                print_file_details(full_path)
    except Exception as e:
        print(f"Error: {e}")
    finally:
        print("")




list_directory(folderPath)