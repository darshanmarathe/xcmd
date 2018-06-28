using System;
using System.IO;

System.Console.WriteLine("");
var CurrentDirectory = Env.ScriptArgs[0];
var extraDir = Env.ScriptArgs[1];
if (extraDir != "-l")
{
    CurrentDirectory += "\\" + extraDir;
}

{

    var DirsArr = Directory.GetDirectories(CurrentDirectory);
    System.Console.WriteLine(" " + DirsArr.Count().ToString() + " directories in " + CurrentDirectory);

    var filearr = Directory.GetFiles(CurrentDirectory);
    System.Console.WriteLine(" " + filearr.Count().ToString() + " files in " + CurrentDirectory);
    System.Console.WriteLine("");
    if (Env.ScriptArgs.Count > 0)
    {
        if (Env.ScriptArgs[1] == "-l")
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            PrintList(DirsArr, false);
            Console.ForegroundColor = ConsoleColor.White;
            PrintList(filearr, true);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Print(DirsArr , false);
            Console.ForegroundColor = ConsoleColor.White;
            Print(filearr, true);
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Print(DirsArr , false);
        Console.ForegroundColor = ConsoleColor.White;
        Print(filearr , true);
    }

}

void Print(string[] arr, bool isFile)
{

    foreach (var file in arr)
    {
        if (isFile)
        {
            FileInfo oFileInfo = new FileInfo(file);
            DateTime dtCreationTime = oFileInfo.LastWriteTime;
            System.Console.WriteLine(oFileInfo.CreationTime.ToString("dd-MMM-yyyy") + "  " + dtCreationTime.ToString("dd-MMM-yyyy hh:mm:ss") + "  " + oFileInfo.Length.ToString() + "  " + oFileInfo.Extension + "  " + file.Replace(CurrentDirectory, ""));
            
            continue;
        }
        System.Console.Write(file.Replace(CurrentDirectory , ""));
        System.Console.Write(" " );
  
    }
    System.Console.WriteLine("");
    System.Console.WriteLine("");
}

void PrintList(string[] arr, bool isFile)
{
    foreach (var file in arr)
    {
        if (isFile)
        {
            FileInfo oFileInfo = new FileInfo(file);
            DateTime dtCreationTime = oFileInfo.LastWriteTime;
            System.Console.Write(oFileInfo.CreationTime.ToString("dd-MMM-yyyy") + "  " + dtCreationTime.ToString("dd-MMM-yyyy hh:mm:ss") + "  " + oFileInfo.Length.ToString() + "  " + oFileInfo.Extension + "  ");
        }
        System.Console.WriteLine(file.Replace(CurrentDirectory + @"\", ""));

    }
    System.Console.WriteLine("");
}
