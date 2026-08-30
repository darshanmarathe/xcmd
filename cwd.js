var path = require('path');
var args = process.argv.slice(2);

function print_help() {
    console.log("Usage: cwd [path]");
    console.log("Copies the current working directory (or specified path) to clipboard");
}

if (args.includes('-h') || args.includes('--help')) {
    print_help();
    process.exit(0);
}

var targetPath = args[0] || process.cwd();
var resolvedPath = path.resolve(targetPath);

console.log(resolvedPath);
require('child_process').spawn('clip').stdin.end(resolvedPath);