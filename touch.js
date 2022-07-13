var fs = require('fs');
 


const thingsToCreate  = process.argv;
thingsToCreate.shift()
thingsToCreate.shift()

var directoryPath = thingsToCreate.pop();



function getDirPath(path ="") {
    if(path === "..")
        {
            let arr =directoryPath.split("\\")
            if(arr[arr.length -1].indexOf(".") > -1)
                arr.pop();
     
            arr.pop()
            directoryPath = arr.join("\\")
            return;
        }
    // if(path.indexOf(".") > -1)
    // {
        let arr =directoryPath.split("\\")
        if(arr[arr.length -1].indexOf(".") > -1)
            arr.pop();
        directoryPath = arr.join("\\")
       directoryPath=  directoryPath + "\\" + path;;
        return;
    // }
    

}


function createFile(path){
 
// writeFile function with filename, content and callback function
if(fs.existsSync(path) === false)    
    fs.writeFileSync(path, '');
}

function createDir(path){
 if(fs.existsSync(path) === false)
    fs.mkdirSync(path);
}
for (const name of thingsToCreate) {
    getDirPath(name);
    if(name != ".."){
        if(name.indexOf(".") > -1){
            createFile(directoryPath)
        }else{
            createDir(directoryPath)
        }
    }
    
}

console.log("files created successfully...")

