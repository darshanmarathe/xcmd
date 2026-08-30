# Xcmd Node.js Related Commands

## Overview

XCMD provides shortcuts for common Node.js and npm operations, making package management and script execution faster and more convenient.

## Command Reference

### Package Management

#### `npi`
Short for `npm install`
- Installs dependencies from package.json
- Without arguments: `npm install`
- With `-l` flag: installs with legacy peer deps

```batch
npi
npi -l
```

#### `npg`
Short for `npm install -g`
- Installs packages globally
- Useful for dev tools, CLIs, and global utilities

```batch
npg <package>
npg @angular/cli
```

#### `npu`
Short for `npm uninstall`
- Removes packages from node_modules
- Preserves package.json entry by default

```batch
npu <package>
npu lodash
```

#### `npr`
Short for `npm run`
- Runs npm scripts defined in package.json
- If no argument: runs `npm run start`

```batch
npr
npr build
npr test
```

#### `npgu`
Short for `npm uninstall -g`
- Removes globally installed packages

```batch
npgu <package>
npgu typescript
```

### Node.js Environment

#### `nodeglobals`
Lists globally installed npm packages
- Shows package names and versions
- Useful for checking what's available globally

```batch
nodeglobals
```

#### `nodelegacy`
Runs Node.js with legacy mode (for older packages)
- Enables compatibility mode for deprecated APIs
- Useful for maintaining legacy Node.js projects

```batch
nodelegacy
```

### Additional Tools

#### `npi`
- Short for `npm install`
- Installs dependencies with legacy peer deps when `-l` flag is used

```batch
npi
npi -l
```

## Usage Examples

### Project Setup

```bash
# Clone and set up new project
npi                 # Install dependencies
npr build           # Build the project
npr test            # Run tests
```

### Package Management

```bash
# Global tools
npg @angular/cli
npg typescript
npg nodemon

# Project dependencies
npi                 # Local install
npu lodash          # Remove package
```

### Script Execution

```bash
# Run npm scripts
npr                 # npm run start
npr build           # npm run build
npr test            # npm run test
```

## Integration

These Node.js commands work seamlessly with other XCMD utilities:
- Use `git clone` to clone repositories
- Use `ls` to view project structure
- Use `cat` to inspect configuration files
- Use `ps` to check for running Node processes

## Requirements

- Node.js must be installed and accessible in PATH
- npm (comes with Node.js) must be available

## Best Practices

1. Always `npi` after cloning a new repository
2. Use `npg` for dev tools that should be globally available
3. Check `nodeglobals` when troubleshooting global package conflicts
4. Use `npu` instead of manually deleting node_modules when removing packages
5. Use `npr` to quickly run project scripts without remembering exact script names