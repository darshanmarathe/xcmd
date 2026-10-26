using System;
using System.IO;
using System.Collections.Generic;

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

List<string> currentFolder = new List<string>();

var scriptArgs = new List<string>(Env.ScriptArgs);
var workingFolder = Environment.CurrentDirectory;
if (scriptArgs.Count > 0 && Directory.Exists(scriptArgs[0]))
{
    workingFolder = scriptArgs[0];
    scriptArgs.RemoveAt(0);
}

foreach (var item in scriptArgs)
{
    if (item == "..")
    {
        if (currentFolder.Count > 0)
        {
            currentFolder.RemoveAt(currentFolder.Count - 1);
        }
        continue;
    }

    var currentDir = currentFolder.Count > 0
        ? Path.Combine(workingFolder, Path.Combine(currentFolder.ToArray()))
        : workingFolder;

    if (IsFileName(item))
    {
        Directory.CreateDirectory(currentDir);
        var fullPath = Path.Combine(currentDir, item);
        if (!File.Exists(fullPath))
        {
            File.Create(fullPath).Dispose();
        }
    }
    else
    {
        currentFolder.Add(item);
        var dirPath = Path.Combine(workingFolder, Path.Combine(currentFolder.ToArray()));
        Directory.CreateDirectory(dirPath);
    }
}

    Log.Success("files created");

bool IsFileName(string name)
{
    if (name.StartsWith(".") && name.Length > 1)
    {
        return true;
    }
    return Path.GetExtension(name) != "";
}
