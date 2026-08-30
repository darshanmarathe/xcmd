import os
import subprocess
import sys

def print_help():
    print("Usage: cwd [path]")
    print("Copies the current working directory (or specified path) to clipboard")

def copy_to_clipboard(text):
    process = subprocess.Popen('clip', stdin=subprocess.PIPE, shell=True)
    process.communicate(input=text.encode())

def main():
    args = sys.argv[1:]
    
    if any(arg in ('-h', '--help', '/?') for arg in args):
        print_help()
        return 0
    
    path = args[0] if args else os.getcwd()
    folderPath = os.path.abspath(path)
    
    print(folderPath)
    copy_to_clipboard(folderPath)
    return 0

if __name__ == "__main__":
    sys.exit(main())