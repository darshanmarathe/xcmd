# XCMD - Enhanced Command Line Interface

A cross-platform command-line toolkit built on top of traditional batch files, providing Unix-like utilities while maintaining compatibility with Windows environments.

## Features

- **Unified Launcher**: A central `launcher.bat` that detects and runs Python, Node.js, or ScriptCs interpreters
- **Cross-Platform Tools**: Commands for process management, environment inspection, file manipulation, and more
- **Consistent Behavior**: All commands follow Unix-style naming and behavior patterns
- **Help System**: Built-in help for all commands

## Commands

### Core Utilities

#### `ps` - Process Listing
Lists running processes with various options.

```bash
ps              # List all processes
ps -a           # List all processes with full command line
ps -f           # Full format listing
ps -e           # Simple process list
```

#### `pgrep` - Process Search
Search for processes by name or PID.

```bash
pgrep               # Search by name
pgrep -f "python"   # Search by full command line
pgrep -a            # Long format
pgrep -h             # Show help
```

#### `env` - Environment Variables
Display all environment variables.

```bash
env                   # Show all environment variables
```

#### `sleep` - Delay Execution
Sleep for a specified amount of time.

```bash
sleep 5             # Wait 5 seconds
sleep 1m            # Wait 1 minute
sleep 2h 30m        # Wait 2 hours and 30 minutes
```

#### `md5sum` - MD5 Hash Calculation
Calculate MD5 checksums for files.

```bash
md5sum              # Calculate checksum for current directory
md5sum file.txt     # Calculate for specific file
md5sum -b           # Binary mode
md5sum -t           # Text mode (default)
```

#### `tree` - Directory Tree
Visualize directory structure.

```bash
tree                  # Show directory tree
tree -a               # Include hidden files
```

#### `cat` - File Content
Display file contents.

```bash
cat file.txt          # Display file content
cat -f file.txt       # Long format
cat -a file.txt       # Show all characters
```

#### `touch` - File Creation
Create empty files or update timestamps.

```bash
touch file.txt       # Create/update file
```

#### `kill` - Process Termination
Terminate processes by name.

```bash
kill <process_name>  # Kill by name
kill -9 <pid>        # Force kill
```

#### `ls` - List Directories
List directory contents.

```bash
ls                      # List current directory
ls -a                   # Include hidden files
ls -l                   # Long format
ls -f                   # Detailed listing
```

#### `cwd` - Change Working Directory
Change to a specified directory.

```bash
cwd <path>             # Change to directory
cwd                     # Current directory
```

#### `list` - List Files
List files with detailed information.

```bash
list <path>             # List files
list -a                  # Include hidden files
list -l                  # Long format
```

### Process Management

```bash
ps                       # Run Python
ps -a                   # All processes
ps -f                   # Full format
ps -e                   # Simple list
```

## Architecture

### Runtime Detection

The core launcher (`launcher.bat`) automatically detects available interpreters:
- **Python** (`python`)
- **Node.js** (`node`)
- **ScriptCs** (`scriptcs`)

It prioritizes Python first, then Node.js, then ScriptCs.

### Cross-Platform Compatibility

All commands are designed to work on Windows while mimicking Unix-style behavior:
- `ps` → `tasklist` (Windows) or `ps` (Unix)
- `pgrep` → `tasklist` or `ps`
- `env` → `echo $VAR` equivalent
- `sleep` → `Start-Sleep` (PowerShell) or `sleep` (Unix)
- `md5sum` → `certutil` or `openssl` (cross-platform)
- `tree` → `dir` (Windows) or `tree` (Unix)
- `cat` → `type` (Windows) or `cat` (Unix)
- `touch` → `mkdir` + `touch`
- `kill` → `taskkill` (Windows) or `kill` (Unix)
- `ls` → `dir` (Windows) or `ls` (Unix)
- `cwd` → `cd` (Windows) or `pwd` (Unix)
- `list` → `dir` (Windows) or `ls` (Unix)

## Usage Examples

### Basic Process Management

```bash
# List all processes
ps

# Find Python processes
ps -a | grep python

# Kill a process by name
kill python

# Force kill a process
kill -9 python
```

### Environment Inspection

```bash
# Show all environment variables
env

# Get specific variable
env HOME
```

### Time Delays

```bash
# Wait 5 seconds
sleep 5

# Wait 2 minutes
sleep 2m

# Wait 3 hours and 45 minutes
sleep 3h 45m
```

### File Operations

```bash
# View file contents
cat file.txt

# Create/update file
touch newfile.txt

# Calculate MD5 hash
md5sum file.txt
```

### Directory Navigation

```bash
# List current directory
ls

# Change to another directory
cwd /path/to/directory

# List with hidden files
ls -a
```

## Integration

This toolkit integrates seamlessly with existing XCMD infrastructure:
- Works alongside `xcmd.bat` and other batch files
- Can be extended with custom commands
- Follows the same architecture as the original XCMD

## Requirements

- **Python 3.x** (for `python` interpreter)
- **Node.js** (optional, for `node` interpreter)
- **ScriptCs** (optional, for `scriptcs` interpreter)
- **Basic POSIX utilities** (for `ps`, `pgrep`, `env`, `sleep`, `md5sum`, `tree`, `cat`, `touch`, `cwd`, `list`)

## Support

For help with any command:
- `command --help` or `command -h`
- `ps --help`
- `pgrep --help`
- `env --help`
- `sleep --help`
- `md5sum --help`
- `tree --help`
- `cat --help`
- `touch --help`
- `kill --help`
- `ls --help`
- `cwd --help`
- `list --help`

## Contributing

All new commands follow the established patterns:
- Main entry point in `.bat` file
- Implementation in corresponding `.py`, `.js`, or `.csx` file
- Help text in the same file
- Proper error handling and exit codes

## License

MIT License - See LICENSE file for details.