var path = require('path');
var fs = require('fs');
//joining path of directory 

console.log(process.argv);
const _path = process.argv[2];

const _isList = ((process.argv[3] || "") === "-l")
console.log('\x1b[36m%s\x1b[0m', _isList); 



var directoryPath =_path;
//passsing directoryPath and callback function
fs.readdirSync(directoryPath, { withFileTypes: true }, function (err, files) {
    //handling error
    if (err) {
        return console.log('Unable to scan directory: ' + err);
    } 

    let fileList = "";
    //listing all files using forEach
    files.forEach(function (file) {
        // Do whatever you want to do with the file
        
        
        console.log(file); 
    });

    files.forEach(function (file) {
        // Do whatever you want to do with the file
        
        
        console.log(file); 
    });
});

