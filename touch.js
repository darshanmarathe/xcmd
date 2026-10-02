const fs = require('fs');
const path = require('path');

const args = process.argv.slice(2);
let baseDir;
if (args.length && fs.existsSync(args[0]) && fs.statSync(args[0]).isDirectory()) {
    baseDir = args.shift();
} else {
    baseDir = process.cwd();
}
let folderStack = [];

function isFileName(name) {
    if (name === '..' || name === '.') return false;
    const ext = path.extname(name);
    return ext !== '' || (name.startsWith('.') && name.length > 1);
}

for (const arg of args) {
    if (arg === '..') {
        folderStack.pop();
        continue;
    }

    const currentDir = folderStack.length ? path.join(baseDir, ...folderStack) : baseDir;

    if (isFileName(arg)) {
        fs.mkdirSync(currentDir, { recursive: true });
        const filePath = path.join(currentDir, arg);
        if (!fs.existsSync(filePath)) {
            fs.writeFileSync(filePath, '');
        }
    } else {
        folderStack.push(arg);
        fs.mkdirSync(path.join(baseDir, ...folderStack), { recursive: true });
    }
}

console.log("files created successfully...");
