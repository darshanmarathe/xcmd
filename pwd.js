
var args = [...process.argv]


let path  = args[2]
console.log(path)

require('child_process').spawn('clip').stdin.end(path);