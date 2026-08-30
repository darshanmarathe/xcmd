const fs = require('fs');
const readline = require('readline');
const path = require('path');

const args = process.argv.slice(2);

const isCopy = args.includes('-c');
const isLine = args.includes('-l');
const filePath = args.find((arg) => !arg.startsWith('-'));

if (!filePath) {
    console.error("no path found ....    ");
    console.log("try cat <filename>");
    console.log("-c for copy file content");
    console.log("-l to show line number");
    process.exit(1);
}

let lineNumber = 1;
let lines = "";

const resolvedPath = path.resolve(filePath);
const rl = readline.createInterface({
    input: fs.createReadStream(resolvedPath, "utf8"),
    output: process.stdout,
    terminal: false
});
rl.on('line', (line) => {
    if (isLine) {
        console.log(`${lineNumber}: ${line}`);
        lineNumber++;
    } else {
        console.log(line);
    }
    if (isCopy) {
        const temp = line + os.EOL;
        lines += temp;
    }
});
rl.on('close', () => {
    if (isCopy) {
        require('child_process').spawn('clip').stdin.end(lines);
        console.log("copied...");
    }
});