using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

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
    Log.Raw("Usage: md5sum [options] [file]");
    Log.Raw("Options:");
    Log.Raw("  -b    Use binary mode");
    Log.Raw("  -t    Use text mode (default)");
    Log.Raw("  -h    Show this help");
    Environment.Exit(0);
}

bool binaryMode = Env.ScriptArgs.Contains("-b");
var files = new List<string>();

foreach (var arg in Env.ScriptArgs)
{
    if (!arg.StartsWith("-"))
        files.Add(arg);
}

using (var md5 = MD5.Create())
{
    if (files.Count == 0)
    {
        byte[] buffer;
        if (binaryMode)
        {
            using (var ms = new MemoryStream())
            {
                Console.OpenStandardInput().CopyTo(ms);
                buffer = ms.ToArray();
            }
        }
        else
        {
            string text = Console.In.ReadToEnd();
            buffer = Encoding.UTF8.GetBytes(text);
        }
        
        byte[] hash = md5.ComputeHash(buffer);
        Log.Raw(BitConverter.ToString(hash).Replace("-", "").ToLower() + "  -");
    }
    else
    {
        foreach (var file in files)
        {
            try
            {
                byte[] buffer;
                if (binaryMode)
                {
                    buffer = File.ReadAllBytes(file);
                }
                else
                {
                    string text = File.ReadAllText(file);
                    buffer = Encoding.UTF8.GetBytes(text);
                }
                
                byte[] hash = md5.ComputeHash(buffer);
                Log.Raw(BitConverter.ToString(hash).Replace("-", "").ToLower() + "  " + file);
            }
            catch (Exception ex)
            {
                Log.Error($"Error: {ex.Message}");
            }
        }
    }
}