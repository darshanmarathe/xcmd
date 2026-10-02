import sys
import os

def isFileName(name):
    ext = os.path.splitext(name)[1]
    return ext != "" or (name.startswith(".") and name != "." and name != "..")

def main():
    args = sys.argv[1:]
    if not args:
        print("Usage: touch <folderName without .ext> fileName.ext ... | .. to go up")
        return
    # bat passes the working directory as the first arg; otherwise use cwd
    if args and os.path.isdir(args[0]):
        baseDir = args[0]
        args = args[1:]
    else:
        baseDir = os.getcwd()
    folderStack = []

    for arg in args:
        if arg == "..":
            if folderStack:
                folderStack.pop()
            continue

        currentDir = os.path.join(baseDir, *folderStack) if folderStack else baseDir

        if isFileName(arg):
            filePath = os.path.join(currentDir, arg)
            os.makedirs(currentDir, exist_ok=True)
            if not os.path.exists(filePath):
                with open(filePath, 'w') as f:
                    f.write('')
        else:
            folderStack.append(arg)
            os.makedirs(os.path.join(baseDir, *folderStack), exist_ok=True)

    print("Files and directories created successfully.")

if __name__ == "__main__":
    main()
