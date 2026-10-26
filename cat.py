import sys
import subprocess
import os


def copy_to_clipboard(text):
    process = subprocess.Popen('clip', stdin=subprocess.PIPE, shell=True)
    process.communicate(input=text.encode())


def get_cat_path(args):
    for i, a in enumerate(args):
        if a == '--cat-path' and i + 1 < len(args):
            return args[i + 1]
    return None


def get_file_path(args):
    i = 0
    while i < len(args):
        a = args[i]
        if a == '--cat-path':
            i += 2  # skip flag + value
            continue
        if a.lower() in ('-c', '-l') or a == '--self':
            i += 1
            continue
        return a
    return None


def main():
    args = sys.argv[1:]
    lower_args = [arg.lower() for arg in args]

    is_copy = '-c' in lower_args
    is_line = '-l' in lower_args
    is_self = '--self' in args
    cat_path = get_cat_path(args)
    filePath = cat_path if is_self else get_file_path(args)

    if not filePath:
        print("no path found ....    ")
        print("try cat <filename>")
        print("-c for copy file content")
        print("-l to show line number")
        print("--self to print the cat command itself")
        sys.exit(1)

    if not os.path.isfile(filePath):
        print(f"Error: '{filePath}' not found")
        sys.exit(1)

    content = ''
    index = 0
    try:
        with open(filePath, 'r') as file:
            for line in file:
                if is_copy:
                    content += line
                if not is_line:
                    print(line, end='')
                else:
                    index += 1
                    print(f"{index}: {line}", end='')
        if is_copy:
            copy_to_clipboard(content)
    except IOError as e:
        print(f"Error reading file: {e}")
        sys.exit(1)


if __name__ == "__main__":
    main()