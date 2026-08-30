import subprocess
import sys
import re

def kill_process(process_name):
    if not re.match(r'^[\w\-\.]+$', process_name):
        print(f"Invalid process name: {process_name}")
        return False
    try:
        subprocess.run(['taskkill', '/F', '/IM', process_name], check=True, stderr=subprocess.STDOUT)
        print(f"Process {process_name} has been killed")
        return True
    except subprocess.CalledProcessError as e:
        print(f"Process {process_name} not found")
        return False
    except Exception as e:
        print(f"Error: {e}")
        return False

if len(sys.argv) < 2:
    print("Usage: kill <process_name>")
    print("Example: kill notepad.exe")
    sys.exit(1)

processName = sys.argv[1]
print(f"Killing Process: {processName} with python")
kill_process(processName)