using System;
using System.Text.RegularExpressions;

var processToKill = Env.ScriptArgs[0];

if (string.IsNullOrWhiteSpace(processToKill))
{
    Console.Error.WriteLine("Usage: kill <process_name>");
    Console.Error.WriteLine("Example: kill notepad");
    Environment.Exit(1);
}

if (!Regex.IsMatch(processToKill, @"^[\w\-\.]+$"))
{
    Console.Error.WriteLine($"Invalid process name: {processToKill}");
    Environment.Exit(1);
}

Console.WriteLine($"Killing process: {processToKill}");

var processes = System.Diagnostics.Process.GetProcessesByName(processToKill);
if (processes.Length == 0)
{
    Console.WriteLine($"Process '{processToKill}' not found");
    Environment.Exit(1);
}

foreach (var process in processes)
{
    try
    {
        process.Kill();
        Console.WriteLine($"Process {process.Id} killed");
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Error killing process {process.Id}: {ex.Message}");
    }
}