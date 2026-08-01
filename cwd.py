import os
import subprocess
import sys


folderPath = os.path.abspath(sys.argv[1])

def copy_to_clipboard(text):
    # Create a temporary process to handle the text with formatting
    process = subprocess.Popen('clip', stdin=subprocess.PIPE, shell=True)
    # Encode string to bytes and preserve all whitespace
    process.communicate(input=text.encode())


print(folderPath)

copy_to_clipboard(folderPath)
