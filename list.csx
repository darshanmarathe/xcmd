using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

static class Log
{
    static void Write(ConsoleColor color, string prefix, string msg)
    {
        var prev = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write($"[{prefix}] ");
        Console.ForegroundColor = prev;
        Console.WriteLine(msg);
    }
    public static void Info(string msg) => Write(ConsoleColor.Gray, "INFO", msg);
    public static void Error(string msg) => Write(ConsoleColor.Red, "ERROR", msg);
    public static void Warn(string msg) => Write(ConsoleColor.Yellow, "WARN", msg);
    public static void Success(string msg) => Write(ConsoleColor.Green, "OK", msg);
    public static void Raw(string msg) => Console.WriteLine(msg);
}

string CurrentDirectory = Env.ScriptArgs[0];

if (Env.ScriptArgs.Contains("-h") || Env.ScriptArgs.Contains("--help") || Env.ScriptArgs.Contains("/?"))
{
    Log.Raw("Usage: ls [options] [path]");
    Log.Raw("Options:");
    Log.Raw("  -l    Long format (detailed listing)");
    Log.Raw("  -h    Show this help");
    Environment.Exit(0);
}

CurrentDirectory = ClearParam(CurrentDirectory);

if (string.IsNullOrEmpty(CurrentDirectory))
{
    CurrentDirectory = Environment.CurrentDirectory;
}

if (!Directory.Exists(CurrentDirectory))
{
    Log.Error($"Error: Directory '{CurrentDirectory}' not found");
    Environment.Exit(1);
}

CurrentDirectory = Path.GetFullPath(CurrentDirectory);
var DirsArr = Directory.GetDirectories(CurrentDirectory);

    Log.Info(" " + DirsArr.Count().ToString() + " directories in " + CurrentDirectory);

    var filearr = Directory.GetFiles(CurrentDirectory);
    Log.Info(" " + filearr.Count().ToString() + " files in " + CurrentDirectory);
    Log.Raw("");

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
            Log.Raw(oFileInfo.CreationTime.ToString("dd-MMM-yyyy") + "  " + oFileInfo.LastWriteTime.ToString("dd-MMM-yyyy hh:mm:ss") + "  " + oFileInfo.Length.ToString() + "  " + oFileInfo.Extension + "  " + file.Replace(CurrentDirectory, ""));
        }
        else
        {
            Log.Raw(file.Replace(CurrentDirectory + @"\", ""));
        }
    }
    Log.Raw("");
    Log.Raw("");
}

void PrintList(string[] arr, bool isFile)
{
    foreach (var file in arr)
    {
        if (isFile)
        {
            FileInfo oFileInfo = new FileInfo(file);
            Log.Raw(oFileInfo.CreationTime.ToString("dd-MMM-yyyy") + "  " + oFileInfo.LastWriteTime.ToString("dd-MMM-yyyy hh:mm:ss") + "  " + oFileInfo.Length.ToString() + "  " + oFileInfo.Extension + "  ");
        }
        Log.Raw(file.Replace(CurrentDirectory + @"\", ""));
    }
    Log.Raw("");
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