import sys
import subprocess


def copy_to_clipboard(text):
    # Create a temporary process to handle the text with formatting
    process = subprocess.Popen('clip', stdin=subprocess.PIPE, shell=True)
    # Encode string to bytes and preserve all whitespace
    process.communicate(input=text.encode())


args = sys.argv[1:]
lower_args = [arg.lower() for arg in args]

is_copy = '-c' in lower_args
is_line = '-l' in lower_args
filePath = next((arg for arg in args if arg.lower() not in ('-c', '-l')), None)

if not filePath:
    print("no path found ....    ")
    print("try cat <filename>")
    print("-c for copy file conent")
    print("-l to show line number")
    sys.exit(1)

content = ''
index = 0
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
