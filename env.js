function print_help() {
    console.log("Usage: env [options]");
    console.log("Options:");
    console.log("  -h    Show this help");
    console.log("");
    console.log("Display environment variables.");
}

const args = process.argv.slice(2);

if (args.includes('-h') || args.includes('--help')) {
    print_help();
    process.exit(0);
}

const envVars = process.env;
const sortedKeys = Object.keys(envVars).sort();

for (const key of sortedKeys) {
    console.log(`${key}=${envVars[key]}`);
}