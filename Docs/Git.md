# Xcmd Git Commands

- [Xcmd Git Commands](#xcmd-git-commands)
    - [clone](#clone)
    - [branch](#branch)
    - [brastat](#brastat)
    - [checkin](#checkin)
    - [commit](#commit)
    - [push](#push)
    - [nBranch](#nbranch)
    - [delBranch](#delbranch)
    - [diff](#diff)
    - [log](#log)
    - [show](#show)
    - [merge](#merge)
    - [remotes](#remotes)
    - [reseth](#reseth)
    - [stashgo](#stashgo)
    - [swbranch](#swbranch)


### clone 

- It clones the repository 
- cd in to that folder
- if node or go project dose the package install 
- opens vs code 

```batch
clone <repository address>
```

### branch 

Shows the current branch 
```batch
branch 
```

Shows all branch 
```batch
branch a
```

### brastat

Shows branch and status
```batch
branch a
```


### checkin

add, commit and push and opens vim for comment
```batch
checkin 
```

add, commit and push 
```batch
checkin "<My comment goes here>"
```
### commit

add, commit and opens vim for comment
```batch
commit 
```

add, commit 
```batch
commit "<My comment goes here>"
```

### push

short to git push 
```batch
push
```

### nBranch

creates branch and sets upstream to origin
```batch
nBranch <new branch name>
```
### delBranch
deletes a branch from local and remote 
```batch
delBranch <branch name>
```

### diff

short to git difftool 
```batch
diff
```
### log

short to git log 
```batch
log
```

short to git log -n shows last -n entries 
```batch
log <number>
```
### show
short to git show 
```batch
show <commitHash>
```

### merge

- Shows your current status
- performs the merge with git merge
- Open VS code and then you can resolve any merge conflicts manually (if any)
- commits and pushes the code  
```batch
merge <branch name>
```

### remotes
Shows all remotes for the current git repository

### reseth
short to git reset --hard

### stashgo
- git stash
- git checkout to branch 
- Shows your current status
- git stash apply

```batch
stashgo <branch name>
```

```batch
stashgo -b <new branch name>
```

### swbranch
- git fetch
- git checkout
- git pull
- Display current branch name  

```batch
swbranch  <branch name>
```


### swbranch
- Removes the last commit for local and remote branch

```batch
rmlastcommit 
```