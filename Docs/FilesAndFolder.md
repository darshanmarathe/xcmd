# Xcmd files-folders Commands

- [Xcmd files-folders Commands](#xcmd-files-folders-commands)
    - [ls](#ls)
    - [ll](#ll)
    - [up](#up)
    - [cdl](#cdl)
    - [mcd](#mcd)
    - [pwd](#pwd)
    - [back](#back)
    - [win](#win)
### ls 

- List the files and folders directory
```batch
ls
ls -l
```

### ll 

short cut for ls -l 
```batch
ll (ls -l) 
```


### up

better cd ..
```batch
up  (cd..)
```

up (n) directories
```batch
C\windows\Microsoft\Microsoft DotNet\6.0\Bin
up  3
C\windows\Microsoft
```

### cdl

cd + ll
```batch
cdl <dirname> 
```

### mcd

Make and cd to dir
```batch
c\code\
mcd app1
c\code\app1 
```

### pwd

Print working dir and copies the path to the memmory 
```batch
pwd
```

### back

sends you back where ever you came from 
```batch
C\windows\Microsoft\Microsoft DotNet\6.0\Bin
up  3
C\windows\Microsoft
back 
C\windows\Microsoft\Microsoft DotNet\6.0\Bin
```


### win

opens windows explorer where you are currently 
```batch
win
```

opens windows explorer by passing path 
```batch
win code\react\app1
```