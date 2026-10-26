using System;
using System.Diagnostics;

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
    Log.Raw("Usage: sleep [number][suffix]...");
    Log.Raw("  suffix may be:");
    Log.Raw("    s - seconds (default)");
    Log.Raw("    m - minutes");
    Log.Raw("    h - hours");
    Log.Raw("    d - days");
    Log.Raw("");
    Log.Raw("Examples:");
    Log.Raw("  sleep 5      # Sleep for 5 seconds");
    Log.Raw("  sleep 1m     # Sleep for 1 minute");
    Log.Raw("  sleep 2h 30m # Sleep for 2 hours and 30 minutes");
    Environment.Exit(0);
}

if (Env.ScriptArgs.Length == 0)
{
    Log.Error("Error: missing operand");
    Log.Error("Try 'sleep --help' for more information.");
    Environment.Exit(1);
}

double totalSeconds = 0;

foreach (var arg in Env.ScriptArgs)
{
    double duration = ParseDuration(arg);
    if (duration < 0)
    {
        Log.Error($"Error: invalid time interval '{arg}'");
        Environment.Exit(1);
    }
    totalSeconds += duration;
}

try
{
    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(totalSeconds));
}
catch (Exception)
{
    Environment.Exit(130);
}

Environment.Exit(0);

double ParseDuration(string durationStr)
{
    if (string.IsNullOrEmpty(durationStr))
        return -1;

    char lastChar = durationStr[durationStr.Length - 1];
    string valuePart;
    char suffix = 's';

    if (char.IsLetter(lastChar))
    {
        suffix = char.ToLower(lastChar);
        valuePart = durationStr.Substring(0, durationStr.Length - 1);
    }
    else
    {
        valuePart = durationStr;
    }

    if (!double.TryParse(valuePart, out double value))
        return -1;

    double multiplier = suffix switch
    {
        's' => 1,
        'm' => 60,
        'h' => 3600,
        'd' => 86400,
        _ => -1
    };

    if (multiplier < 0)
        return -1;

    return value * multiplier;
}