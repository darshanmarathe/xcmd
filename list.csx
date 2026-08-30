using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

string CurrentDirectory = Env.ScriptArgs[0];

if (Env.ScriptArgs.Contains("-h") || Env.ScriptArgs.Contains("--help") || Env.ScriptArgs.Contains("/?"))
{
    System.Console.WriteLine("Usage: ls [options] [path]");
    System.Console.WriteLine("Options:");
    System.Console.WriteLine("  -l    Long format (detailed listing)");
    System.Console.WriteLine("  -h    Show this help");
    Environment.Exit(0);
}

CurrentDirectory = ClearParam(CurrentDirectory);

if (string.IsNullOrEmpty(CurrentDirectory))
{
    CurrentDirectory = Environment.CurrentDirectory;
}

if (!Directory.Exists(CurrentDirectory))
{
    Console.Error.WriteLine($"Error: Directory '{CurrentDirectory}' not found");
    Environment.Exit(1);
}

CurrentDirectory = Path.GetFullPath(CurrentDirectory);
var DirsArr = Directory.GetDirectories(CurrentDirectory);

Console.WriteLine(" " + DirsArr.Count().ToString() + " directories in " + CurrentDirectory);

var filearr = Directory.GetFiles(CurrentDirectory);
Console.WriteLine(" " + filearr.Count().ToString() + " files in " + CurrentDirectory);
Console.WriteLine("");

if (HasParam("-l"))
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    PrintList(DirsArr, false);
    Console.ForegroundColor = ConsoleColor.White;
    PrintList(filearr, true);
}
else
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Print(DirsArr, false);
    Console.ForegroundColor = ConsoleColor.White;
    Print(filearr, true);
}

void Print(string[] arr, bool isFile)
{
    foreach (var file in arr)
    {
        if (isFile)
        {
            FileInfo oFileInfo = new FileInfo(file);
            Console.WriteLine(oFileInfo.CreationTime.ToString("dd-MMM-yyyy") + "  " + oFileInfo.LastWriteTime.ToString("dd-MMM-yyyy hh:mm:ss") + "  " + oFileInfo.Length.ToString() + "  " + oFileInfo.Extension + "  " + file.Replace(CurrentDirectory, ""));
        }
        else
        {
            Console.Write(file.Replace(CurrentDirectory + @"\", ""));
            Console.Write(" ");
        }
    }
    Console.WriteLine("");
    Console.WriteLine("");
}

void PrintList(string[] arr, bool isFile)
{
    foreach (var file in arr)
    {
        if (isFile)
        {
            FileInfo oFileInfo = new FileInfo(file);
            Console.WriteLine(oFileInfo.CreationTime.ToString("dd-MMM-yyyy") + "  " + oFileInfo.LastWriteTime.ToString("dd-MMM-yyyy hh:mm:ss") + "  " + oFileInfo.Length.ToString() + "  " + oFileInfo.Extension + "  ");
        }
        Console.WriteLine(file.Replace(CurrentDirectory + @"\", ""));
    }
    Console.WriteLine("");
}

bool HasParam(string swi)
{
    foreach (var item in Env.ScriptArgs)
    {
        if (item == swi.ToLower() || item == swi.ToUpper())
            return true;
    }
    return false;
}

string ClearParam(string Param)
{
    if (string.IsNullOrEmpty(Param))
        return Environment.CurrentDirectory;
    if (Param.Contains("\""))
        return Param.Replace("\"", "\\").Split(' ')[0];
    else
        return Param.Trim();
}