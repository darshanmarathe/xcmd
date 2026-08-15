#r "System.Windows.Forms"


using System.Windows.Forms;
using System.Threading;

string filePath = GetFilePath(Env.ScriptArgs);

if (string.IsNullOrWhiteSpace(filePath))
{
    System.Console.Error.WriteLine("no path found ....    ");
    System.Console.WriteLine("try cat <filename>");
    System.Console.WriteLine("-c for copy file conent");
    System.Console.WriteLine("-l to show line number");
    System.Environment.Exit(1);
}

filePath = System.IO.Path.GetFullPath(filePath);
string[] lines = System.IO.File.ReadAllLines(filePath);

if (HasParam("-l"))
{
    for (int i = 0; i  < lines.Length; i++)
    {
        var line = lines[i];
        Console.WriteLine((i + 1).ToString() + ":\t" + line);
    }
}
else
{
   foreach (string line in lines)
    {
        // Use a tab to indent each line of the file.
        Console.WriteLine(line);
    }
}

if (HasParam("-c"))
{
    var content = string.Join("\n" , lines);
    var thread = new Thread(() => {
        Clipboard.SetText(content);
        System.Console.WriteLine("content copied to clipboard");
    });
    thread.SetApartmentState(ApartmentState.STA);
    thread.IsBackground = false;
    thread.Start();
    thread.Join();
}




bool HasParam(string swi){
    foreach (var item in Env.ScriptArgs)
    {
        if(item == swi.ToLower() || item == swi.ToUpper())
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
