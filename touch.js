


const thingsToCreate  = process.argv;
thingsToCreate.shift()
thingsToCreate.shift()

var directoryPath = thingsToCreate.pop();



function getDirPath(path ="") {
    if(path === "..")
        {
            let arr =directoryPath.split("\\")
            arr.pop();
            
            directoryPath = arr.join("\\")
            return;
        }
    if(path.indexOf(".") > -1)
    {
        let arr =directoryPath.split("\\")
        if(arr[arr.length -1].indexOf(".") > -1)
            arr.pop();
        directoryPath = arr.join("\\")
       directoryPath=  directoryPath + "\\" + path;;
        return;
    }

    directoryPath =  directoryPath + "\\" + path; 
}


for (const name of thingsToCreate) {
    getDirPath(name);
    console.log(directoryPath)
    
}
