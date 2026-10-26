#r "System.Windows.Forms"

using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;

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

if (Env.ScriptArgs.Contains("-h") || Env.ScriptArgs.Contains("--help") || Env.ScriptArgs.Contains("/?"))
{
    Log.Raw("Usage: cwd [path]");
    Log.Raw("Copies the current working directory (or specified path) to clipboard");
    Environment.Exit(0);
}

string targetPath = Env.ScriptArgs.Count > 0 ? Env.ScriptArgs[0] : Directory.GetCurrentDirectory();
string content = Path.GetFullPath(targetPath);

Log.Raw(content);

var thread = new Thread(() => {
    Clipboard.SetText(content);
});
thread.SetApartmentState(ApartmentState.STA);
thread.IsBackground = false;
thread.Start();
thread.Join();