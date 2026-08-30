import time
import sys

def print_help():
    print("Usage: sleep [number][suffix]...")
    print("  suffix may be:")
    print("    s - seconds (default)")
    print("    m - minutes")
    print("    h - hours")
    print("    d - days")
    print("")
    print("Examples:")
    print("  sleep 5      # Sleep for 5 seconds")
    print("  sleep 1m     # Sleep for 1 minute")
    print("  sleep 2h 30m # Sleep for 2 hours and 30 minutes")

def parse_duration(duration_str):
    suffix = duration_str[-1].lower() if duration_str[-1].isalpha() else 's'
    try:
        value = float(duration_str[:-1]) if suffix != 's' or duration_str[-1].isalpha() else float(duration_str)
    except ValueError:
        return None
    
    multipliers = {
        's': 1,
        'm': 60,
        'h': 3600,
        'd': 86400
    }
    
    if suffix not in multipliers:
        return None
    
    return value * multipliers[suffix]

def main():
    args = sys.argv[1:]
    
    if any(arg in ('-h', '--help', '/?') for arg in args):
        print_help()
        return 0
    
    if not args:
        print("Error: missing operand")
        print("Try 'sleep --help' for more information.")
        return 1
    
    total_seconds = 0
    
    for arg in args:
        duration = parse_duration(arg)
        if duration is None:
            print(f"Error: invalid time interval '{arg}'")
            return 1
        total_seconds += duration
    
    try:
        time.sleep(total_seconds)
    except KeyboardInterrupt:
        return 130
    
    return 0

if __name__ == "__main__":
    sys.exit(main())