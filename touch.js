const fs = require('fs');
const path = require('path');

const args = process.argv.slice(2);
let currentPath = process.cwd();

function createFile(filePath) {
    if (!fs.existsSync(filePath)) {
        fs.writeFileSync(filePath, '');
    }
}

function createDir(dirPath) {
    if (!fs.existsSync(dirPath)) {
        fs.mkdirSync(dirPath, { recursive: true });
    }
}

for (const name of args) {
    if (name === "..") {
        currentPath = path.dirname(currentPath);
    } else if (name.includes(".")) {
        createFile(path.join(currentPath, name));
    } else {
        createDir(path.join(currentPath, name));
    }
}

console.log("files created successfully...");