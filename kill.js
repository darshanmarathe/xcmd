const processToKill  = process.argv[2];
console.log(processToKill);
const child_process = require('child_process');

const displayProcessBy = (pattern) => {
    let command = `ps -aux | grep ${pattern}`;
    child_process.exec(command, (err, stdout, stdin) => {
        if (err) throw err;
        console.log(stdout);
    });
}

displayProcessBy(processToKill);