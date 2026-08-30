# XCMD Editors Commands

## Overview

XCMD provides shortcuts for popular code editors and IDEs, making it easy to jump directly into your development environment from the command line.

## Command Reference

### Code (Visual Studio Code)

#### `codei`
Open current directory in Visual Studio Code
- Equivalent to `code .` in terminal
- Opens the current working directory
- If no folder specified, opens VS Code in the current directory

```batch
codei
```

#### `codei <path>`
Open specific directory in Visual Studio Code

```batch
codei C:\project\my-app
codei /path/to/project
codei .\subfolder
```

### Visual Studio Code (Alternative)

#### `code`
Alias for `codei` - open in VS Code

```batch
code <path>
```

### Sublime Text

#### `subl`
Open current directory in Sublime Text

```batch
subl
subl src\app
```

### Vim

#### `vi`
Open current directory in Vim

```batch
vi
```

#### `vim`
Alias for `vi`

```batch
vim
```

### Atom

#### `atom`
Open current directory in Atom

```batch
atom
```

### JetBrains IDEs

#### `idea`
Open project in JetBrains IDEA
- Supports IntelliJ IDEA, PyCharm, WebStorm, etc.

```batch
idea
```

#### `pycharm`
Open Python project in PyCharm

```batch
pycharm
```

#### `webstorm`
Open web project in WebStorm

```batch
webstorm
```

### Notepad++

#### `notepad++`
Open current file in Notepad++

```batch
notepad++
```

### Emacs

#### `emacs`
Open current directory in Emacs

```batch
emacs
```

### Brackets

#### `brackets`
Open project in Brackets

```batch
brackets
```

### VS Code Insiders

#### `code-insiders`
Open in VS Code Insiders (development version)

```batch
code-insiders
```

### Windsurf

#### `windsurf`
Open project in Windsurf

```batch
windsurf
```

### Cursor

#### `cursor`
Open project in Cursor

```batch
cursor
```

## Integration with Development Workflow

### Common Editor Commands

```bash
# Jump to your project
git clone https://github.com/user/project
codei project

# Work with current file
vi .gitignore
cat README.md
ls

# Switch editors quickly
subl
atom
vim
```

### Project Development

```bash
# Clone and open in VS Code
clone https://github.com/user/project
codei project

# Check project structure
ls

# View configuration
cat package.json
cat settings.json

# Make changes
vi index.html
```

### Debugging and Testing

```bash
# Quick project setup
codei
ls -la
```

### Code Editing

```bash
# Open files for editing
vi .env
vi config.js

# Check what's available in your project
ls
ls -l
```

## Editor Configuration Examples

### VS Code Settings

```json
{
  "terminal.integrated.shell.windows": "C:\\Program Files\\Git\\bin\\sh.exe",
  "editor.formatOnSave": true,
  "files.autoSave": "afterDelay"
}
```

### Sublime Text Configuration

```json
{
  "tabSize": 2,
  "translateTabsToSpaces": true,
  "fontSize": 14
}
```

### Vim Configuration

```vim
:set number
set tabstop=4
set shiftwidth=4
set expandtab
```

## Requirements

- Editors must be installed and accessible in PATH
- For cross-platform support: editors should have Windows versions

## Best Practices

1. Use shortcuts consistently for faster development
2. Set up your editor preferences before starting
3. Use multiple editors for different tasks:
   - VS Code: General development
   - Vim: Quick edits, terminal-friendly
   - Sublime: Fast navigation, clean UI
4. Link projects to your favorite editor
5. Set up editor-specific hotkeys

## Editor Selection Guide

| Task | Recommended Editor | Reason |
|------|-------------------|---------|
| Web Development | VS Code | Excellent extensions, Git integration |
| Python Development | VS Code/PyCharm | Great Python support |
| Quick Edits | Vim | Keyboard-driven, terminal friendly |
| Front-end | VS Code | Best for web files |
| Backend | VS Code/IntelliJ | Strong language support |

## Additional Tips

### Set Up Default Editor

```bash
# Set VS Code as default editor
code --set-default-path

# Set for specific file types
git config --global core.editor "code --wait"
```

### Editor-Specific Workflows

```bash
# VS Code workflow
codei
subl
vim
atom
```

# For terminal development
vim
```

# For GUI development
codei
subl
```

## Integration with XCMD

These editor commands work seamlessly with other XCMD utilities:
- Use `git clone` to clone repositories
- Use `ls` to view project structure
- Use `cat` to inspect files
- Use `ps` to check for running processes
- Use `env` to view environment variables