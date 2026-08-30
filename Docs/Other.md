# XCMD Other Commands

## Setup Machine

Installs Chocolatey and sets up machine with many software packages for development:
- New languages (Rust, Julia, etc.)
- Text editors (Sublime, VS Code, Atom)
- Many more development tools

```batch
setupmachine -y        # Install all software by default
```

## StartWork

Customize this batch file for your daily workflow:
- Pull latest code
- Open Visual Studio Code
- Automate everything you do daily

```bash
startwork
```

## Commands for Git (Making you lazy...)

### Checkin

Replaces `git add .` + `git commit -m "comment"` + `git push`

```bash
checkin                         # Opens editor for commit message
checkin "Your comment here"     # Uses provided message
```

### Branch

Quickly check which branch you are on

```bash
branch                          # Current branch
branch a                        # List all branches
```

### Status

Quickly check current branch status

```bash
status
```

### Clone

Quickly clone a repository

```bash
clone <repo_name>
clone <repo_name> <folder_name>
```

## Commands Linux Bash Style (bash++)

### Cat

To see file contents

```bash
cat <file_name>              # Display file
cat <file_name> -l           # With line numbers
cat <file_name> -c           # Display and copy to clipboard
```

### Ls

To see directory contents

```bash
ls                           # List directory
ls -l                        # With details
ls -c                        # Copy to clipboard
```

## Commands Other

### Bash

Opens Git Bash in CMD; exit with `exit` to return to CMD

```bash
bash
```

### Editors

### Sublime

Open Sublime Text editor

```bash
subl
```

### Vim

Open Vim editor

```bash
vi
```

### VS Code

Open Visual Studio Code

```bash
codei
```

### Terminal

Open a new terminal window

```bash
terminal
```

## Utilities

### AddToPath

Add current directory to PATH

```bash
AddToPath
```

### Bash

Open Git Bash

```bash
bash
```

### Bash10

Show branch and status

```bash
bash10
```

### iisRok

ngrok for IIS - Expose local IIS to internet

```bash
iisRok
```

### Kill

Kill a process (requires admin mode)

```bash
kill node
kill app1
```

### Mongo

Start MongoDB

```bash
mongo
```

### Py

Run Python code

```bash
py app.py
```

### Serv

Start HTTP server in current directory

```bash
serv                 # Current directory
serv dist            # Specific directory
```

### Zip

Zip a folder (requires 7zip)

```bash
zip <foldername>
```

### Unzip

Unzip a file

```bash
unzip <file_name>
```

### Tsw

Start TypeScript in watch mode

```bash
tsw app.ts
```

### SetupMachine

Set up machine for developer

```bash
setupmachine
```

## Additional Documentation

For more detailed information:
- [Docker Commands](Docs/Docker.md)
- [Node.js Commands](Docs/Node.md)
- [Git Commands](Docs/Git.md)
- [File and Folder Commands](Docs/FilesAndFolder.md)
- [Utility Commands](Docs/Utils.md)