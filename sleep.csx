using System;
using System.Diagnostics;

if (Env.ScriptArgs.Contains("-h") || Env.ScriptArgs.Contains("--help") || Env.ScriptArgs.Contains("/?"))
{
    System.Console.WriteLine("Usage: sleep [number][suffix]...");
    System.Console.WriteLine("  suffix may be:");
    System.Console.WriteLine("    s - seconds (default)");
    System.Console.WriteLine("    m - minutes");
    System.Console.WriteLine("    h - hours");
    System.Console.WriteLine("    d - days");
    System.Console.WriteLine("");
    System.Console.WriteLine("Examples:");
    System.Console.WriteLine("  sleep 5      # Sleep for 5 seconds");
    System.Console.WriteLine("  sleep 1m     # Sleep for 1 minute");
    System.Console.WriteLine("  sleep 2h 30m # Sleep for 2 hours and 30 minutes");
    Environment.Exit(0);
}

if (Env.ScriptArgs.Length == 0)
{
    Console.Error.WriteLine("Error: missing operand");
    Console.Error.WriteLine("Try 'sleep --help' for more information.");
    Environment.Exit(1);
}

double totalSeconds = 0;

foreach (var arg in Env.ScriptArgs)
{
    double duration = ParseDuration(arg);
    if (duration < 0)
    {
        Console.Error.WriteLine($"Error: invalid time interval '{arg}'");
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