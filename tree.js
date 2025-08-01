const fs = require('fs');
const path = require('path');

const ignoredNames = new Set(['.git', '.scriptcs_cache', '.vs', '.vscode', 'node_modules', 'compiled']);

let totalDirs = 0;
let totalFiles = 0;

function generateTree(dir, prefix = '') {
    let items;
    try {
        items = fs.readdirSync(dir);
    } catch (e) {
        // console.error(`Error reading directory ${dir}: ${e.message}`);
        return;
    }

    // Filter out ignored items
    const filteredItems = items.filter(item => !ignoredNames.has(item));

    filteredItems.forEach((item, index) => {
        const itemPath = path.join(dir, item);
        const isLast = index === filteredItems.length - 1;
        const connector = isLast ? '└── ' : '├── ';
        
        console.log(prefix + connector + item);

        try {
            const stats = fs.statSync(itemPath);
            if (stats.isDirectory()) {
                totalDirs++;
                const newPrefix = prefix + (isLast ? '    ' : '│   ');
                generateTree(itemPath, newPrefix);
            } else {
                totalFiles++;
            }
        } catch (e) {
            // console.error(`Error stating item ${itemPath}: ${e.message}`);
        }
    });
}

const targetDir = process.argv[2] || '.';
const resolvedDir = path.resolve(targetDir);

console.log(resolvedDir); // Print the root directory being treed

// Start the tree generation
try {
    const stats = fs.statSync(resolvedDir);
    if (stats.isDirectory()) {
        totalDirs++; // Count the root directory itself
        generateTree(resolvedDir);
    } else {
        console.log(`Error: ${resolvedDir} is not a directory.`);
        process.exit(1);
    }
} catch (e) {
    console.log(`Error: Could not access ${resolvedDir}. ${e.message}`);
    process.exit(1);
}


// Print summary
console.log(`\n${totalDirs} directories, ${totalFiles} files`);