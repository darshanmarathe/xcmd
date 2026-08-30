function print_help() {
    console.log("Usage: sleep [number][suffix]...");
    console.log("  suffix may be:");
    console.log("    s - seconds (default)");
    console.log("    m - minutes");
    console.log("    h - hours");
    console.log("    d - days");
    console.log("");
    console.log("Examples:");
    console.log("  sleep 5      # Sleep for 5 seconds");
    console.log("  sleep 1m     # Sleep for 1 minute");
    console.log("  sleep 2h 30m # Sleep for 2 hours and 30 minutes");
}

function parseDuration(durationStr) {
    let value, suffixChar;
    
    const lastChar = durationStr[durationStr.length - 1];
    if (lastChar && lastChar.match(/[a-zA-Z]/)) {
        suffixChar = lastChar.toLowerCase();
        value = parseFloat(durationStr.slice(0, -1));
    } else {
        suffixChar = 's';
        value = parseFloat(durationStr);
    }
    
    const multipliers = {
        's': 1,
        'm': 60,
        'h': 3600,
        'd': 86400
    };
    
    if (isNaN(value) || !(suffixChar in multipliers)) {
        return null;
    }
    
    return value * multipliers[suffixChar];
}

const args = process.argv.slice(2);

if (args.includes('-h') || args.includes('--help')) {
    print_help();
    process.exit(0);
}

if (args.length === 0) {
    console.error("Error: missing operand");
    console.error("Try 'sleep --help' for more information.");
    process.exit(1);
}

let totalSeconds = 0;

for (const arg of args) {
    const duration = parseDuration(arg);
    if (duration === null) {
        console.error(`Error: invalid time interval '${arg}'`);
        process.exit(1);
    }
    totalSeconds += duration;
}

const totalMs = totalSeconds * 1000;

const start = Date.now();
while (Date.now() - start < totalMs) {
    // Busy wait to avoid async complications
}

process.exit(0);