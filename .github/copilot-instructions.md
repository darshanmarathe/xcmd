# XCMD Codebase Instructions

## Project Overview

XCMD ("bash++") is a Windows command-line utility collection that wraps developer workflows into convenient batch scripts. It's designed to make Windows CMD feel more like bash by providing git, npm, docker, file utilities, and project-specific commands.

**Architecture**: Multi-language polyglot where single-purpose utilities are implemented in parallel:
- `.bat` files: Shell scripts for Windows CMD (primary, always sync with source implementations)
- `.csx` files: ScriptCS (C# as script) implementations - often more feature-rich
- `.js` files: Node.js versions for npm environments
- `.py` files: Python implementations for Python projects
- `.csproj`/`.sln` in `compiled/`: Compiled C# versions (legacy, may be outdated)

## Key Patterns & Conventions

### 1. Multi-Language Implementations
The same command exists in multiple languages. Example: `cat` command:
- `cat.bat` - Simple batch wrapper
- `cat.csx` - Full featured (supports `-c` clipboard copy, `-l` line numbers)
- `cat.js` - Node version with streaming for large files
- `cat.py` - Python version

**For contributors**: If modifying functionality, update all versions to maintain parity. The `.csx` version typically has the most features; backport essential changes to `.bat`.

### 2. Batch File Structure
All batch files follow the pattern:
```batch
@echo off
[validation checks]
[core logic or delegation]
```

Key idioms:
- `WHERE <command>` checks if a tool is installed, sets `%ERRORLEVEL%`
- `IF %ERRORLEVEL% NEQ 0` handles missing dependencies
- `call refreshenv` updates PATH after chocolatey installs
- `call <command>` delegates to other batch files or external tools

Example: `npi.bat` wraps npm with legacy peer deps handling
```batch
IF [%1]==[-l] (
    call npm install %* --legacy-peer-deps
) ELSE (
    call npm install %*
)
```

### 3. Command Categories
Organize commands in `Docs/` by domain:
- **Git**: `clone`, `branch`, `push`, `pull`, `commit`, `merge` → `Docs/Git.md`
- **Package Managers**: `npi` (npm), `npr`, `npu` → documented inline
- **Utilities**: `cat`, `ls`, `kill`, `zip`, `serv` → `Docs/Utils.md`
- **System Setup**: `SetupMachine.bat`, `AddToPath.bat`, `nodeglobals.bat`
- **Node/Dev Tools**: `watch.bat` (nodemon wrapper), `tsw.bat` (typescript watch)

### 4. Installation & Setup
- Add scripts to PATH: Run `AddToPath.bat` or `install.bat`
- Full machine setup: `SetupMachine.bat` (installs chocolatey, git, nvm, node, browsers, dev tools)
- Project initialization: `clone` runs `npm install` or `go get` automatically
- Node global packages: `nodeglobals.bat` installs global npm tools (called by SetupMachine if Node found)

### 5. External Dependencies & Integration
- **Chocolatey**: Package manager; scripts check for it and auto-install
- **ScriptCS**: `#r` references enable System.Windows.Forms for clipboard operations
- **Nodemon**: Required by `watch.bat` for file monitoring
- **Git**: Foundation for version control commands
- **7zip**: Required by `zip` command

### 6. Clipboard Operations
`.csx` files use System.Windows.Forms for clipboard:
```csharp
#r "System.Windows.Forms"
using System.Windows.Forms;
Clipboard.SetText(content);
```

Must run in STA (Single Threaded Apartment) thread - see `cat.csx` thread handling example.

## Development Workflows

### Adding a New Command
1. Implement `.bat` version in root (required, must work standalone)
2. Add `.csx` version if logic is complex or needs clipboard/system APIs
3. Optionally add `.js` and `.py` versions for multi-platform support
4. Document in appropriate `Docs/*.md` file with usage examples
5. Add to `README.md` command list if user-facing

### Testing a Command
```batch
[command] -? 
```
Most commands accept `-?` or `-h` for help (implement if adding new commands).

### Modifying Existing Functionality
- If changing `.bat` behavior, test the corresponding `.csx`/`.js`/`.py` versions
- Update all language versions to match if fixing bugs
- Ensure `SetupMachine.bat` still validates dependencies correctly

## Project File Structure

```
/                    # Root scripts (primary interface)
  *.bat              # Batch wrappers (priority - always tested)
  *.csx              # ScriptCS implementations (more features)
  *.js/*.py          # Alt language implementations
  README.md          # Main documentation & command list

compiled/            # Legacy compiled C# (may be outdated, avoid unless modernizing)
  cat/cat/*.csproj
  ls/ls/*.csproj
  touch/touch/*.csproj

Docs/                # Domain-specific documentation
  Git.md             # 18 git-related commands
  Utils.md           # Utility functions
  FilesAndFolder.md  # File/folder operations
  Node.md            # npm/node helpers
  Docker.md          # Docker wrappers
  Other.md           # Misc commands
```

## Critical Files to Understand First

1. `SetupMachine.bat` - Shows full machine setup, dependency chain, chocolatey integration
2. `Docs/Git.md` - Exemplifies command documentation structure
3. `cat.bat` + `cat.csx` - Show single-command multi-language pattern
4. `watch.bat` - Example of dependency validation and tool wrapping
5. `README.md` - Project mission and tech stack

## Common Debugging

- **Script not found**: Run `AddToPath.bat` to add current dir to PATH
- **Command fails silently**: Add `@echo off` removal to see batch output
- **ScriptCS errors**: Verify ScriptCS installed via `WHERE scriptcs`; check `#r` references
- **Clipboard not working**: ScriptCS clipboard ops require STA threading (see `cat.csx` pattern)

## Contributing Guidelines

- Batch-first: Every command **must** have a working `.bat` version
- Cross-check implementations: If modifying logic, test all language versions
- Document tradeoffs: Note why certain features exist only in one language
- Preserve backwards compatibility: Don't break existing command signatures
