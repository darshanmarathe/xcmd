using System;
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

var processToKill = Env.ScriptArgs[0];

if (string.IsNullOrWhiteSpace(processToKill))
{
    Log.Error("Usage: kill <process_name>");
    Log.Error("Example: kill notepad");
    Environment.Exit(1);
}

    if (!Regex.IsMatch(processToKill, @"^[\w\-\.\s]+$"))
{
    Log.Error($"Invalid process name: {processToKill}");
    Environment.Exit(1);
}

Log.Info($"Killing process: {processToKill}");

var processes = System.Diagnostics.Process.GetProcessesByName(processToKill);
if (processes.Length == 0)
{
    Log.Warn($"Process '{processToKill}' not found");
    Environment.Exit(1);
}

foreach (var process in processes)
{
    try
    {
        process.Kill();
        Log.Success($"Process {process.Id} killed");
    }
    catch (Exception ex)
    {
        Log.Error($"Error killing process {process.Id}: {ex.Message}");
    }
}