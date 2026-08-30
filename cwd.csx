using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;

if (Env.ScriptArgs.Contains("-h") || Env.ScriptArgs.Contains("--help") || Env.ScriptArgs.Contains("/?"))
{
    System.Console.WriteLine("Usage: cwd [path]");
    System.Console.WriteLine("Copies the current working directory (or specified path) to clipboard");
    Environment.Exit(0);
}

string targetPath = Env.ScriptArgs.Length > 0 ? Env.ScriptArgs[0] : Directory.GetCurrentDirectory();
string content = Path.GetFullPath(targetPath);

Console.WriteLine(content);

var thread = new Thread(() => {
    Clipboard.SetText(content);
});
thread.SetApartmentState(ApartmentState.STA);
thread.IsBackground = false;
thread.Start();
thread.Join();