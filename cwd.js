
var args = [...process.argv]

const { resolve } = require('path');

let path  = resolve(args[2])
console.log(path)

require('child_process').spawn('clip').stdin.end(path);