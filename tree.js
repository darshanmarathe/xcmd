const fs = require('fs');
const path = require('path');

function print_help() {
    console.log("Usage: tree [options] [directory]");
    console.log("Options:");
    console.log("  -a    Show all files (including hidden)");
    console.log("  -L    Limit depth");
    console.log("  -h    Show this help");
}

function clearParam(param) {
    if (!param) return path.resolve(".");
    if (param.includes('"')) {
        return path.resolve(param.replace(/"/g, "\\").split(' ')[0]);
    }
    return path.resolve(param.trim());
}

const args = process.argv.slice(2);

if (args.includes('-h') || args.includes('--help')) {
    print_help();
    process.exit(0);
}

const targetArg = process.argv[2] || '.';
const directoryPath = clearParam(targetArg);

if (!fs.existsSync(directoryPath)) {
    console.error(`Error: Directory '${directoryPath}' not found`);
    process.exit(1);
}

if (!fs.statSync(directoryPath).isDirectory()) {
    console.error(`Error: '${directoryPath}' is not a directory`);
    process.exit(1);
}

function tree(dir, prefix = '', isLast = true) {
    const children = fs.readdirSync(dir)
        .filter(name => !args.includes('-a') || name[0] !== '.')
        .map(name => ({ name, path: path.join(dir, name) }));
    
    children.forEach((child, index) => {
        const isLastChild = index === children.length - 1;
        const line = prefix + (isLastChild ? "└── " : "├── ") + child.name;
        console.log(line);
        
        if (fs.statSync(child.path).isDirectory()) {
            const newPrefix = prefix + (isLastChild ? "    " : "│   ");
            tree(child.path, newPrefix, isLastChild);
        }
    });
}

console.log(directoryPath);
tree(directoryPath);