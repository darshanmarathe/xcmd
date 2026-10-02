# Xcmd Utility Commands

- [Xcmd Utility Commands](#xcmd-utility-commands)
    - [AddToPath](#addtopath)
    - [bash](#bash)
    - [bash10](#bash10)
    - [env](#env)
    - [iisRok](#iisrok)
    - [kill](#kill)
    - [mongo](#mongo)
    - [py](#py)
    - [serv](#serv)
    - [zip](#zip)
    - [unzip](#unzip)
    - [tsw](#tsw)
    - [setupmachine](#setupmachine)


### AddToPath 

- Permanently adds current directory to the **User** PATH environment variable via `setx`
- Affects new terminal sessions only (existing terminals need to be reopened)
- Does not require admin privileges

```batch
AddToPath
```

### bash 

Shows the current branch 
```batch
branch 
```

Shows all branch 
```batch
branch a
```

### bash10

Shows branch and status
```batch
branch a
```

### env

Display all environment variables sorted alphabetically

```batch
env
```

Show help
```batch
env -h
```

### iisRok

ngRok for IIS 
```batch
iisRok
```

### kill

kill process (works only in admin mode)
 origin
```batch
kill node
kill app1
```
### mongo
start mongo db 
```batch
mongo
```

### py

Run python code
```batch
py app.py
```
### serv

starts http server in current dir 
```batch
serv 
```

starts http server in given dir 
```batch
serv dist
```

### zip
Zips the folder (requires 7zip)
```batch
zip <foldername>
```

### unzip

- Unzips a file
```batch
unzip <file name>
```

### tsw
start type script in watch mode
 repository
```batch
tsw app.ts
```


### setupmachine
Sets up machine for developer
```batch
setupmachine
```
