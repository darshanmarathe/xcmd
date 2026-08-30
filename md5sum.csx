using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

if (Env.ScriptArgs.Contains("-h") || Env.ScriptArgs.Contains("--help") || Env.ScriptArgs.Contains("/?"))
{
    System.Console.WriteLine("Usage: md5sum [options] [file]");
    System.Console.WriteLine("Options:");
    System.Console.WriteLine("  -b    Use binary mode");
    System.Console.WriteLine("  -t    Use text mode (default)");
    System.Console.WriteLine("  -h    Show this help");
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
        Console.WriteLine(BitConverter.ToString(hash).Replace("-", "").ToLower() + "  -");
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
                Console.WriteLine(BitConverter.ToString(hash).Replace("-", "").ToLower() + "  " + file);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}