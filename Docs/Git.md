# Xcmd Git Commands

Comprehensive Git command shortcuts for daily development workflow.

## Overview

XCMD provides a collection of batch file shortcuts for common Git operations, making version control faster and more intuitive. These commands work alongside standard Git commands while providing convenient wrappers for frequent tasks.

## Command Reference

### Repository Management

#### `clone <repository>` 
Clone a repository and set up the development environment
- Clones the repository to current directory
- Changes directory into the cloned repo
- For Node.js/Go projects: runs package installation
- Opens VS Code automatically

```batch
clone https://github.com/user/repo.git
```

#### `remotes`
Show all remote repositories for the current project

```batch
remotes
```

### Branch Operations

#### `branch`
Show current branch name

```batch
branch
```

#### `branch a` or `branch --all`
Show all branches (local and remote)

```batch
branch a
```

#### `nBranch <name>`
Create new branch and set upstream to origin
- Creates branch locally
- Sets up tracking with origin
- Checks out the new branch

```batch
nBranch feature/new-feature
```

#### `delBranch <name>`
Delete branch from both local and remote repositories
- Deletes local branch
- Deletes remote branch (if exists)

```batch
delBranch feature/old-feature
```

#### `swbranch <name>`
Switch to branch with automatic update
- Fetches latest from origin
- Checks out specified branch
- Pulls latest changes
- Shows current branch name

```batch
swbranch main
```

### Status and History

#### `status`
Show current git status (short form of `git status`)

```batch
status
```

#### `log`
Show commit history (last 10 commits by default)
- Shows graph view with commit details
- Default: last 10 commits

```batch
log
```

#### `log <number>`
Show last N commits
- Shows graph view of last N commits

```batch
log 20
```

#### `show <commit>`
Show details of specific commit
- Shows commit diff and metadata
- Accepts commit hash, branch name, or tag

```batch
show abc123def
```

### File Operations

#### `diff`
Show file differences (uses difftool if configured)
- Shows unstaged changes
- Uses configured diff tool or default diff

```batch
diff
```

#### `diff <file>`
Show differences for specific file

```batch
diff src/app.js
```

### Commit Workflow

#### `commit`
Stage all changes and open editor for commit message
- Stages all modified and new files (`git add .`)
- Opens default editor for commit message
- Commits when editor closes

```batch
commit
```

#### `commit "<message>"`
Stage all changes and commit with message
- Stages all modified and new files
- Commits with provided message

```batch
commit "Fix login validation bug"
```

#### `checkin`
Complete workflow: stage, commit, and push
- Stages all changes
- Opens editor for commit message
- Commits and pushes to origin

```batch
checkin
```

#### `checkin "<message>"`
Stage, commit, and push with predefined message

```batch
checkin "Add user authentication feature"
```

### Synchronization

#### `push`
Push current branch to origin
- Pushes to upstream branch
- Sets upstream if not already set

```batch
push
```

#### `push <branch>`
Push specific branch to origin

```batch
push feature/new-feature
```

### Advanced Operations

#### `merge <branch>`
Merge branch into current branch with conflict resolution
- Shows current status
- Performs git merge
- Opens VS Code to resolve conflicts (if any)
- Commits and pushes after resolution

```batch
merge main
```

#### `reseth`
Reset current branch to match origin (hard reset)
- Equivalent to `git reset --hard`
- Use with caution - discards local changes

```batch
reseth
```

#### `stashgo <branch>`
Stash changes, switch branch, and apply stash
- Stashes local changes
- Checks out specified branch
- Applies stashed changes
- For new branch: `stashgo -b <new-branch>`

```batch
stashgo main
stashgo -b feature/from-stash
```

#### `rmlastcommit`
Remove last commit from local and remote
- Removes most recent commit locally
- Force pushes to update remote
- Use with care on shared branches

```batch
rmlastcommit
```

### Configuration

#### `gitsafe`
Add current directory to Git safe directories
- Prevents "unsafe repository" warnings
- Adds current path to git config --global safe.directory

```batch
gitsafe
```

## Usage Examples

### Daily Workflow

```bash
# Start working on existing repo
status          # Check what's changed
log             # See recent commits

# Make changes...
edit some-file.js

# Commit changes
commit "Fix navigation bug"
# or
checkin "Add new feature"

# Share changes
push            # Push to remote
```

### Feature Development

```bash
# Start new feature
nBranch feature/payment-processing
# Work on feature...
commit "Add payment validation"
push            # Push feature branch

# Finish feature
swbranch main           # Switch to main
merge feature/payment-processing  # Merge and resolve conflicts
delBranch feature/payment-processing  # Clean up
```

### Emergency Fixes

```bash
# Save work and switch to main
stashgo main
# Fix critical issue
commit "Fix security vulnerability"
push
# Return to previous work
stashgo main
```

## Integration with XCMD

These Git commands work seamlessly with other XCMD utilities:
- Use `ls` to see repository structure
- Use `cat` to view file contents
- Use `grep` to search code
- Use `ps` to check for running processes
- Use `env` to inspect environment variables

## Requirements

- Git must be installed and accessible in PATH
- For automatic VS Code opening: Code must be installed
- For repository setup: appropriate language runtimes (Node, Go, etc.) may be needed

## Best Practices

1. Use descriptive commit messages
2. Push feature branches regularly for backup
3. Delete merged branches to keep repo clean
4. Use `stashgo` when needing to switch contexts quickly
5. Always check `status` before committing
6. Use `log` to review history before merging