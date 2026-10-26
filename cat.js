const fs = require('fs');
const readline = require('readline');
const path = require('path');

const args = process.argv.slice(2);

const isCopy = args.includes('-c');
const isLine = args.includes('-l');
const isSelf = args.includes('--self');

// --cat-path <value> is injected by cat.bat with the bat's own full path.
let catPath = null;
for (let i = 0; i < args.length; i++) {
    if (args[i] === '--cat-path' && i + 1 < args.length) {
        catPath = args[i + 1];
        break;
    }
}

let filePath;
if (isSelf) {
    filePath = catPath;
} else {
    for (let i = 0; i < args.length; i++) {
        if (args[i] === '--cat-path') { i++; continue; } // skip flag + value
        const arg = args[i];
        if (!arg.startsWith('-')) { filePath = arg; break; }
    }
}

if (!filePath) {
    console.error("no path found ....    ");
    console.log("try cat <filename>");
    console.log("-c for copy file content");
    console.log("-l to show line number");
    console.log("--self to print the cat command itself");
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