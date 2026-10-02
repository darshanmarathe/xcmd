using System;
using System.IO;
using System.Collections.Generic;

List<string> currentFolder = new List<string>();

var scriptArgs = new List<string>(Env.ScriptArgs);
var workingFolder = Environment.CurrentDirectory;
if (scriptArgs.Count > 0 && Directory.Exists(scriptArgs[0]))
{
    workingFolder = scriptArgs[0];
    scriptArgs.RemoveAt(0);
}

foreach (var item in scriptArgs)
{
    if (item == "..")
    {
        if (currentFolder.Count > 0)
        {
            currentFolder.RemoveAt(currentFolder.Count - 1);
        }
        continue;
    }

    var currentDir = currentFolder.Count > 0
        ? Path.Combine(workingFolder, Path.Combine(currentFolder.ToArray()))
        : workingFolder;

    if (IsFileName(item))
    {
        Directory.CreateDirectory(currentDir);
        var fullPath = Path.Combine(currentDir, item);
        if (!File.Exists(fullPath))
        {
            File.Create(fullPath).Dispose();
        }
    }
    else
    {
        currentFolder.Add(item);
        var dirPath = Path.Combine(workingFolder, Path.Combine(currentFolder.ToArray()));
        Directory.CreateDirectory(dirPath);
    }
}

Console.WriteLine("files created");

bool IsFileName(string name)
{
    if (name.StartsWith(".") && name.Length > 1)
    {
        return true;
    }
    return Path.GetExtension(name) != "";
}
