using System;
using System.IO;
using System.Collections.Generic;

List<string> currentFolder = new List<string>();

var workingFolder = Environment.CurrentDirectory;

foreach (var item in Env.ScriptArgs)
{
    if (item == "..")
    {
        RemoveLast(currentFolder);
        continue;
    }

    var fullPath = Join(currentFolder) + "\\" + item;

    if (item.Contains("."))
    {
        if (!File.Exists(fullPath))
        {
            File.Create(fullPath).Dispose();
        }
    }
    else
    {
        currentFolder.Add(item);
        var dirPath = Join(currentFolder);
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
    }
}

Console.WriteLine("files created");

void RemoveLast(List<string> list)
{
    list.RemoveAt(list.Count - 1);
}

string Join(List<string> list)
{
    return workingFolder + "\\" + string.Join("\\", list.ToArray());
}