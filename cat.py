import sys

import subprocess

def copy_to_clipboard(text):
    cmd = f'echo {text.strip()}|clip'
    subprocess.check_call(cmd, shell=True)


def copy_to_clipboard_2(text):
    # Create a temporary process to handle the text with formatting
    process = subprocess.Popen('clip', stdin=subprocess.PIPE, shell=True)
    # Encode string to bytes and preserve all whitespace
    process.communicate(input=text.encode())


filePath = sys.argv[1] 

print(f"Reading file: {filePath} with python")

args = sys.argv[1:]

is_copy =  '-c' in args
is_line = '-l' in args

str = ''
index =0
with open(filePath , 'r') as file:
    for line in file:
        if is_copy:
            str += line + '\n'
        if not is_line:
            print(line.strip())
        else:
            index+=1
            print(f"{index}: {line.strip()}")
if is_copy:
    copy_to_clipboard_2(str)
