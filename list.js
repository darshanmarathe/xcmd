var path = require("path");
var fs = require("fs");
//joining path of directory
const _path = ClearParam(process.argv[2]);
console.log(_path)

let _isList = (() => {
    if((process.argv[3] || "") === "-l")
        return true;
    if ((process.argv[2] || "").includes("-l")) {
        return true;
    } 
    return false;
})();
    


var directoryPath = _path;
console.log(directoryPath);
console.log("");
//passsing directoryPath and callback function
fs.readdir(directoryPath, { withFileTypes: true }, function (err, files) {
  //handling error
  if (err) {
    return console.log("Unable to scan directory: " + err);
  }
  let fileList = "";
  const dirCount = files.filter((x) => x.isDirectory() === true).length;
  const fileCount = files.filter((x) => x.isDirectory() === false).length;

  console.log(` ${dirCount} directories in ${directoryPath}`);
  console.log(` ${fileCount} files in ${directoryPath}`);
  console.log("");
  //listing all files using forEach
  files.forEach(function (file) {
    // Do whatever you want to do with the file
    if (file.isDirectory()) {
      console.log("\x1b[36m%s\x1b[0m", file.name);
    }
  });

  files.forEach(function (file) {
    // Do whatever you want to do with the file

    function createdDate(file) {
      let __filepath = directoryPath + "\\" + file.name;
      const { birthtime, size } = fs.statSync(__filepath);
      //console.log(fs.statSync(__filepath))
      return { time: birthtime.toDateString(), size };
    }

    if (!file.isDirectory()) {
      if (_isList) {
        try {
            const { time, size } = createdDate(file);
            fileList += `${time} , ${size} b  ${file.name}  \n`;
                
        } catch (error) {
            fileList += file.name + "      ";    
        }
      } else {
        fileList += file.name + "      ";
      }
    }
  });
  console.log("");
  console.log(fileList);
});



function ClearParam(Param = '')
{
    if (Param.includes("\""))
        return Param.replace("\"", "\\").split(' ')[0];
    else
        return Param.trim();
}

