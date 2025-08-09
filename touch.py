import sys
import os

args = sys.argv[1:]

# get the last argument
currentPath = sys.argv[-1]

args.pop()


def createFile(path):
    if os.path.exists(path) == False:
        with open(path, 'w') as f:
            f.write('')

def createDir(path):
    if os.path.exists(path) == False:
        os.makedirs(path)
    global currentPath  # Add this line
    currentPath = path
    print(currentPath)


for i in args:
    if i == "..":
        currentPath = currentPath.split("\\")
        currentPath.pop()
        currentPath = "\\".join(currentPath)
        continue
    elif '.' in i:
        createFile(currentPath + "\\" + i)
    else:
        createDir(currentPath + "\\" + i)


print("Files and directories created successfully.")
sys.exit(0)
