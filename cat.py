import sys
import subprocess
import os


def copy_to_clipboard(text):
    process = subprocess.Popen('clip', stdin=subprocess.PIPE, shell=True)
    process.communicate(input=text.encode())


def main():
    args = sys.argv[1:]
    lower_args = [arg.lower() for arg in args]

    is_copy = '-c' in lower_args
    is_line = '-l' in lower_args
    filePath = next((arg for arg in args if arg.lower() not in ('-c', '-l')), None)

    if not filePath:
        print("no path found ....    ")
        print("try cat <filename>")
        print("-c for copy file content")
        print("-l to show line number")
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