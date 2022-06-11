const fs = require('fs')
const readline = require('readline');
const os = require("os");

var args = [...process.argv]

if (args.length >= 3 && args[2].indexOf('.') > -1 ) {

    args.shift()
    args.shift();
    
    const isCopy = args.includes('-c')
    const isLine = args.includes('-l')

    let lineNumber =1
    let lines  = ""
    
    const path = args[0].replace(/\\/g , "\\\\");
    const rl = readline.createInterface({
        input: fs.createReadStream(path, "utf8"),
        output: process.stdout,
        terminal: false
    });
    rl.on('line', (line) => {

        if(isLine){
            console.log(`${lineNumber}: ${line}`)
            lineNumber++;
        }else{

            console.log(line);
        }
        if(isCopy){
     
            lines += line + '\r\n';
        
 
        }
    });
    rl.on('close' , () => {
       if(isCopy){
        const util = require('util');
        require('child_process').spawn('clip').stdin.end(util.inspect(lines));
       }
    })
}else{
    console.error("no path found ....    ")
    console.log("try cat <filename>")
    console.log("-c for copy file conent")
    console.log("-l to show line number")
    process.exit(1)
}
