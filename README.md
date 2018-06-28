# XCMD aka bash++
Super batch commands for windows

xcmd makes your good old command line super command line if you like bash it will make CMD bash++ .

  - Powered by batch files + ScriptCs
  - Makes developers love command line again 
  - Magic

# New Features!

  - cat can copy the content of file
  - stashgo (stash command on staroieds)


### Tech

ScriptCS + Chocolaty (Optional) + good old batch files

* [scriptCS] - C# as Script
* [Batch files] - Run your cmd in Batch
* [Chocolaty] - Apt-get for windows

### Installation

    - clone or Download XCMD From [github](https://github.com/darshanmarathe/xcmd.git) v1 .
    - Set PATH variable for this folder

### Development

Want to contribute? Great!


License
----

MIT


**Free Software, Hell Yeah!**

# Commands (Making you lazy...)
## Setup Machine

Installs chocolaty and sets up machine with many of software(s) for e.g new languages like rust, julia text editors like sublime, vscode, atom and much much more just look into batch file remove / add whatever you need and run it with -y flag and goto sleep/coffee/movie by the time you are back machine is ready 

    - setupnacine
    - setupmachine -y (install all software by default)

## StartWork

Just change this batch file for what ever your daily stuff pulling latest code opening visual studio code just be lazy and automate everything

    - startwork


# Commands for Git (Making you lazy...)
## checkin
checkin replaces [git add .  / git commit -m "your comment here" / git push] so now in case of fire checkin 

    - checkin   
    - checkin "your comment here"

## branch
Quickly check which branch you are on replaces [git branch]

    - branch   
    - branch a (list all branches)

## status
Quickly check what is the status of current branch you are on, replaces [git status]

    - status   



# Commands Linux bash style(i call it bash++)
## cat 
to see whats in file 

    - cat <fileName>   
    - cat <fileName> -l  (to see line numbers)
    - cat <filename> -c  (see and copy to clipboard)


# Commands Other 
## bash

Opens git bash in cmd you can exit command in bash to come back to cmd 
   
    - bash
