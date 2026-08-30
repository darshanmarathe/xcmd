var execSync = require('child_process').execSync;
var platform = require('os').platform;

function print_help() {
    console.log("Usage: pgrep [options] name...");
    console.log("Options:");
    console.log("  -f    Match full command line");
    console.log("  -a    Show command name only");
    console.log("  -h    Show this help");
}

var args = process.argv.slice(2);
var names = [];

for (var i = 0; i < args.length; i++) {
    if (args[i] === '-f') continue;
    if (args[i] === '-a') continue;
    if (args[i] === '-h' || args[i] === '--help') {
        print_help();
        process.exit(0);
    }
    names.push(args[i]);
}

if (names.length === 0) {
    console.error("Error: Please provide at least one process name to search");
    process.exit(1);
}

try {
    if (platform() === 'win32') {
        var output = execSync('tasklist').toString();
        var lines = output.split('\n');
        var found = [];
        
        for (var i = 3; i < lines.length; i++) {
            var line = lines[i].trim();
            if (!line) continue;
            
            var parts = line.split(/,\s*/);
            if (parts.length >= 1) {
                var pid = parts[0].replace(/"/g, '');
                var image_name = parts[1].replace(/"/g, '');
                var cmd_line = parts.slice(3).join(' ').replace(/"/g, '');
                
                for (var j = 0; j < names.length; j++) {
                    var pattern = names[j].toLowerCase();
                    if (cmd_line.toLowerCase().includes(pattern) || image_name.toLowerCase().includes(pattern)) {
                        found.push({pid: pid, cmd_line: cmd_line, image_name: image_name});
                        break;
                    }
                }
            }
        }
        
        if (found.length === 0) {
            process.exit(1);
        }
        
        for (var k = 0; k < found.length; k++) {
            console.log(found[k].pid + ':' + found[k].image_name);
        }
    } else {
        var output = execSync('ps aux').toString();
        var lines = output.split('\n');
        var found = [];
        
        for (var i = 1; i < lines.length; i++) {
            var line = lines[i].trim();
            if (!line) continue;
            var parts = line.split(/\s+/);
            
            if (parts.length >= 11) {
                var pid = parts[1];
                var cmd = parts[10];
                
                for (var j = 0; j < names.length; j++) {
                    var pattern = names[j].toLowerCase();
                    if (cmd.toLowerCase().includes(pattern)) {
                        found.push({pid: pid, cmd: cmd});
                        break;
                    }
                }
            }
        }
        
        if (found.length === 0) {
            process.exit(1);
        }
        
        for (var k = 0; k < found.length; k++) {
            console.log(found[k].pid);
        }
    }
} catch (error) {
    console.error('Error:', error.message);
    process.exit(1);
}