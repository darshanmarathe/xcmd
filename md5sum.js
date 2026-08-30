const crypto = require('crypto');
const fs = require('fs');

function print_help() {
    console.log("Usage: md5sum [options] [file]");
    console.log("Options:");
    console.log("  -b    Use binary mode");
    console.log("  -t    Use text mode (default)");
    console.log("  -h    Show this help");
}

const args = process.argv.slice(2);

if (args.includes('-h') || args.includes('--help')) {
    print_help();
    process.exit(0);
}

const binary_mode = args.includes('-b');
const files = args.filter(arg => !arg.startsWith('-'));

if (files.length === 0) {
    const chunks = [];
    process.stdin.on('readable', () => {
        let chunk;
        while ((chunk = process.stdin.read()) !== null) {
            chunks.push(chunk);
        }
    });
    process.stdin.on('end', () => {
        const data = Buffer.concat(chunks);
        const md5 = crypto.createHash('md5').update(data).digest('hex');
        console.log(`${md5}  -`);
    });
} else {
    files.forEach(file => {
        try {
            const buffer = fs.readFileSync(file, binary_mode ? null : 'utf8');
            const md5 = crypto.createHash('md5').update(buffer).digest('hex');
            console.log(`${md5}  ${file}`);
        } catch (error) {
            console.error(`Error: ${error.message}`);
        }
    });
}