using System;
using System.Linq;

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
    Log.Raw("Usage: env [options]");
    Log.Raw("Options:");
    Log.Raw("  -h    Show this help");
    Log.Raw("");
    Log.Raw("Display environment variables.");
    Environment.Exit(0);
}

var envVars = Environment.GetEnvironmentVariables();
var sortedKeys = new System.Collections.Generic.List<string>();

foreach (System.Collections.DictionaryEntry entry in envVars)
{
    sortedKeys.Add(entry.Key.ToString());
}

sortedKeys.Sort();

foreach (var key in sortedKeys)
{
    Log.Raw($"{key}={envVars[key]}");
}