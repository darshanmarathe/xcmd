import subprocess
import sys

processName = sys.argv[1]

print(f"Killing Process: {processName} with python")



def kill_process(process_name):
    try:
        # Using taskkill
        subprocess.run(['taskkill', '/F', '/IM', process_name], check=True)
        print(f"Process {process_name} has been killed")
        return True
    except subprocess.CalledProcessError:
        print(f"Process {process_name} not found")
        return False


kill_process(processName)
