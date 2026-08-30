const path = require("path");
const fs = require("fs");

function print_help() {
    console.log("Usage: ls [options] [path]");
    console.log("Options:");
    console.log("  -l    Long format (detailed listing)");
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
const isList = args.includes('-l');

console.log(directoryPath);
console.log("");

fs.readdir(directoryPath, { withFileTypes: true }, function (err, files) {
    if (err) {
        return console.log("Unable to scan directory: " + err);
    }
    const dirCount = files.filter((x) => x.isDirectory()).length;
    const fileCount = files.filter((x) => !x.isDirectory()).length;

    console.log(` ${dirCount} directories in ${directoryPath}`);
    console.log(` ${fileCount} files in ${directoryPath}`);
    console.log("");

    files.filter(f => f.isDirectory()).forEach(function (file) {
        console.log("\x1b[36m%s\x1b[0m", file.name);
    });

    files.filter(f => !f.isDirectory()).forEach(function (file) {
        if (isList) {
            const filePath = path.join(directoryPath, file.name);
            try {
                const stats = fs.statSync(filePath);
                console.log(`${stats.birthtime.toDateString()} , ${stats.size} b  ${file.name}`);
            } catch (error) {
                console.log(file.name);
            }
        } else {
            console.log(file.name);
        }
    });
    console.log("");
});