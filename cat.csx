using System;
using System.IO;
using System.Text.RegularExpressions;

string filePath = GetFilePath(Env.ScriptArgs);

if (string.IsNullOrWhiteSpace(filePath))
{
    System.Console.Error.WriteLine("no path found ....    ");
    System.Console.Error.WriteLine("try cat <filename>");
    System.Console.Error.WriteLine("-c for copy file conent");
    System.Console.Error.WriteLine("-l to show line number");
    System.Environment.Exit(1);
}

if (!File.Exists(filePath))
{
    System.Console.Error.WriteLine($"Error: File '{filePath}' not found");
    System.Environment.Exit(1);
}

filePath = System.IO.Path.GetFullPath(filePath);
string[] lines = System.IO.File.ReadAllLines(filePath);

if (HasParam("-l"))
{
    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i];
        Console.WriteLine((i + 1).ToString() + ":\t" + line);
    }
}
else
{
    foreach (string line in lines)
    {
        Console.WriteLine(line);
    }
}

if (HasParam("-c"))
{
    var content = string.Join("\n", lines);
    var thread = new Thread(() => {
        Clipboard.SetText(content);
        System.Console.WriteLine("content copied to clipboard");
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
        if (item == swi.ToLower() || item == swi.ToUpper())
            return true;
    }
    return false;
}

bool IsSwitch(string value)
{
    return value == "-c" || value == "-C" || value == "-l" || value == "-L";
}

string GetFilePath(string[] args)
{
    foreach (var item in args)
    {
        if (!IsSwitch(item))
            return item;
    }
    return null;
}