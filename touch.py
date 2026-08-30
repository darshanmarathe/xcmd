import sys
import os

def createFile(path):
    if not os.path.exists(path):
        with open(path, 'w') as f:
            f.write('')

def createDir(path):
    if not os.path.exists(path):
        os.makedirs(path)

def main():
    args = sys.argv[1:]
    currentPath = os.getcwd()

    for arg in args:
        if arg == "..":
            currentPath = os.path.dirname(currentPath)
        elif '.' in arg:
            createFile(os.path.join(currentPath, arg))
        else:
            createDir(os.path.join(currentPath, arg))

    print("Files and directories created successfully.")

if __name__ == "__main__":
    main()