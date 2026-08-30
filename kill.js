var child_process = require('child_process');

var processName = process.argv[2];

if (!processName) {
    console.error("Error: Please provide a process name to kill");
    console.error("Usage: kill <process_name>");
    process.exit(1);
}

console.log("Killing process: " + processName);

try {
    var result = child_process.execSync('taskkill /F /IM ' + processName, { encoding: 'utf8' });
    console.log("Process killed successfully");
    console.log(result);
    process.exit(0);
} catch (error) {
    if (error.status === 128) {
        console.error("Error: Process '" + processName + "' not found");
    } else {
        console.error("Error killing process: " + error.stderr || error.message);
    }
    process.exit(1);
}