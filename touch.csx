using System.IO;
using System.Linq;

List<string> currentfolder  =new List<string>();

foreach (var item in Env.ScriptArgs)
{
  //  System.Threading.Thread.Sleep(1000);
    if(item == ".."){
        
            Console.ForegroundColor = ConsoleColor.Yellow;  
                      System.Console.WriteLine(Join(currentfolder) + @"\..");
       RemoveLast(currentfolder);
     
 
       Console.ForegroundColor = ConsoleColor.White;  
        continue;
    }
        

    if (item.Contains("."))
    {   
         System.Console.WriteLine("creating file " + item);
         if(currentfolder.Count ==0)
           File.Create(item);
         else
            File.Create(Join(currentfolder) + @"\" + item);        
    }else{
          Console.ForegroundColor = ConsoleColor.DarkGreen;  
        currentfolder.Add(item);
        System.Console.WriteLine("creating folder " + Join(currentfolder));
        Directory.CreateDirectory(Join(currentfolder));
          Console.ForegroundColor = ConsoleColor.White;  
    }
    
}

void RemoveLast(List<string> list){
    list.RemoveAt(list.Count - 1);
}

string Join(List<string> list){
    var retval = String.Join(@"\" ,list.ToArray());
     return  retval;
}