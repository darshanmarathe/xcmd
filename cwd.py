import subprocess
import sys


folderPath = sys.argv[1]
args = sys.argv[1:]

def copy_to_clipboard(text):
    # Create a temporary process to handle the text with formatting
    process = subprocess.Popen('clip', stdin=subprocess.PIPE, shell=True)
    # Encode string to bytes and preserve all whitespace
    process.communicate(input=text.encode())


print(args[0])

copy_to_clipboard(args[0])
