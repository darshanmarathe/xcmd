#r "System.Windows.Forms"

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

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

string catPath = GetOptionValue(Env.ScriptArgs, "--cat-path");
bool isSelf = HasParam("--self");
string filePath = isSelf ? catPath : GetFilePath(Env.ScriptArgs);
System.Console.Write(filePath);

if (string.IsNullOrWhiteSpace(filePath))
{
    Log.Error("no path found ....");
    Log.Error("try cat <filename>");
    Log.Error("-c for copy file content");
    Log.Error("-l to show line number");
    Log.Error("--self to print the cat command itself");
    System.Environment.Exit(1);
}

filePath = System.IO.Path.GetFullPath(filePath.Trim());

if (!File.Exists(filePath))
{
    Log.Error($"Error: File '{filePath}' not found");
    Log.Error($"Resolved path: {filePath}");
    System.Environment.Exit(1);
}

string[] lines = System.IO.File.ReadAllLines(filePath);

if (HasParam("-l"))
{
    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        Log.Raw((i + 1).ToString() + ":\t" + line);
    }
}
else
{
    foreach (string line in lines)
    {
        Log.Raw(line);
    }
}

if (HasParam("-c"))
{
    var content = string.Join("\n", lines);
    var thread = new Thread(() => {
        Clipboard.SetText(content);
        Log.Success("content copied to clipboard");
    });
    thread.SetApartmentState(ApartmentState.STA);
    thread.IsBackground = false;
    thread.Start();
    thread.Join();
}

bool HasParam(string swi)
{
    foreach (var item in Env.ScriptArgs)
    {
        if (string.Equals(item, swi, StringComparison.OrdinalIgnoreCase))
            return true;
    }
    return false;
}

bool IsSwitch(string value)
{
    return value == "-c" || value == "-C"
        || value == "-l" || value == "-L"
        || string.Equals(value, "--self", StringComparison.OrdinalIgnoreCase)
        || string.Equals(value, "--cat-path", StringComparison.OrdinalIgnoreCase);
}

string GetFilePath(IReadOnlyList<string> args)
{
    for (int i = 0; i < args.Count; i++)
    {
        var item = args[i];
        if (string.Equals(item, "--cat-path", StringComparison.OrdinalIgnoreCase))
        {
            i++; // skip the value that follows --cat-path
            continue;
        }
        if (!IsSwitch(item))
            return item;
    }
    return null;
}

string GetOptionValue(IReadOnlyList<string> args, string option)
{
    for (int i = 0; i < args.Count; i++)
    {
        if (string.Equals(args[i], option, StringComparison.OrdinalIgnoreCase) && i + 1 < args.Count)
            return args[i + 1];
    }
    return null;
}