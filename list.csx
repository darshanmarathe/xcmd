#r "System.Windows.Forms"


using System.Windows.Forms;
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;


var CurrentDirectory = Env.ScriptArgs[0];
var content = new List<string> ();
WriteLine("");

    var DirsArr = Directory.GetDirectories(CurrentDirectory);
    WriteLine(" " + DirsArr.Count().ToString() + " directories in " + CurrentDirectory);

    var filearr = Directory.GetFiles(CurrentDirectory);
    WriteLine(" " + filearr.Count().ToString() + " files in " + CurrentDirectory);
    WriteLine("");

    if (IsSwitchAvaible("-l"))
    {

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        PrintList(DirsArr, false);
        Console.ForegroundColor = ConsoleColor.White;
        PrintList(filearr, true);
        Copy();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Print(DirsArr , false);
        Console.ForegroundColor = ConsoleColor.White;
        Print(filearr, true);
        Copy();
    }

void Copy(){
    if(IsSwitchAvaible("-c"))
    {
        var _content = string.Join("\n" , content);
        Write(_content);
        var thread = new Thread(() => {
            Clipboard.SetText(_content);
            System.Console.WriteLine("content copied to clipboard");
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.IsBackground = false;
        thread.Start();
        thread.Join();
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
            WriteLine(oFileInfo.CreationTime.ToString("dd-MMM-yyyy") + "  " + dtCreationTime.ToString("dd-MMM-yyyy hh:mm:ss") + "  " + oFileInfo.Length.ToString() + "  " + oFileInfo.Extension + "  " + file.Replace(CurrentDirectory, ""));
            
            continue;
        }
        Write(file.Replace(CurrentDirectory , ""));
        Write(" " );
  
    }
    WriteLine("");
    WriteLine("");
}

void PrintList(string[] arr, bool isFile)
{
    foreach (var file in arr)
    {
        if (isFile)
        {
            FileInfo oFileInfo = new FileInfo(file);
            DateTime dtCreationTime = oFileInfo.LastWriteTime;
            Write(oFileInfo.CreationTime.ToString("dd-MMM-yyyy") + "  " + dtCreationTime.ToString("dd-MMM-yyyy hh:mm:ss") + "  " + oFileInfo.Length.ToString() + "  " + oFileInfo.Extension + "  ");
        }
        WriteLine(file.Replace(CurrentDirectory + @"\", ""));

    }
    WriteLine("");
}

void Write(string message){
    content.Add(message);
    System.Console.Write(message);
}

void WriteLine(string message){
    content.Add(message);
    System.Console.WriteLine(message);
}


bool IsSwitchAvaible(string swi){
    foreach (var item in Env.ScriptArgs)
    {
        if(item == swi.ToLower() || item == swi.ToUpper())
            return true; 
    }
    return false;
}