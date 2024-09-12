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
    - [cat](#cat)
    - [touch](#touch)
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

### cat

Shows the file content 
```batch
cat package.json
```

Shows the file content with line numbers
```batch
cat package.json -l
```
Shows the file content and copies it
```batch
cat package.json -c
```

### touch

creates files
```batch
touch index.html 
touch index.html about.html contact.html
```

create folders 
```batch
touch src js 
src 
    js

```


Ultimate project creator
```batch
REM create for hotel website
touch index.html contact.html about.html rooms large.html double.html single.html .. css style.css js index.js vendor jquery.js .. .. reademe.md  

index.html
contact.html
about.html 
readme.md 
rooms
    large.html
    double.html 
    single.html
css 
    style.css
js
    index.js
    vendor 
        jquery.js
```
