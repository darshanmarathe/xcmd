using System;
using System.Linq;

if (Env.ScriptArgs.Contains("-h") || Env.ScriptArgs.Contains("--help") || Env.ScriptArgs.Contains("/?"))
{
    System.Console.WriteLine("Usage: env [options]");
    System.Console.WriteLine("Options:");
    System.Console.WriteLine("  -h    Show this help");
    System.Console.WriteLine("");
    System.Console.WriteLine("Display environment variables.");
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
    Console.WriteLine($"{key}={envVars[key]}");
}