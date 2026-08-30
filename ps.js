const { execSync } = require('child_process');
const os = require('os');

function print_help() {
    console.log("Usage: ps [options]");
    console.log("Options:");
    console.log("  -a    Show all processes with full command line");
    console.log("  -f    Full format listing");
    console.log("  -h    Show this help");
}

const args = process.argv.slice(2);

if (args.includes('-h') || args.includes('--help')) {
    print_help();
    process.exit(0);
}

const show_all = args.includes('-a') || args.includes('-f');

try {
    if (os.platform() === 'win32') {
        let cmd = 'tasklist';
        if (show_all) {
            cmd += ' /V';
        }
        const output = execSync(cmd, { encoding: 'utf8' });
        console.log(output);
    } else {
        let cmd = 'ps';
        if (show_all) {
            cmd += ' -ef';
        } else {
            cmd += ' -e';
        }
        const output = execSync(cmd, { encoding: 'utf8' });
        console.log(output);
    }
} catch (error) {
    console.error('Error listing processes:', error.message);
    process.exit(1);
}