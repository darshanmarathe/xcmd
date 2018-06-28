#r "System.Windows.Forms"


using System.Windows.Forms;
using System.Threading;

System.Console.WriteLine("");
// Read each line of the file into a string array. Each element
// of the array is one line of the file.
System.Console.WriteLine(Env.ScriptArgs[0] + "\\" + Env.ScriptArgs[1]);
string[] lines = System.IO.File.ReadAllLines(Env.ScriptArgs[0] + "\\" + Env.ScriptArgs[1]);

if (IsSwitchAvaible("-l"))
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

if (IsSwitchAvaible("-c"))
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




bool IsSwitchAvaible(string swi){
    foreach (var item in Env.ScriptArgs)
    {
        if(item == swi.ToLower() || item == swi.ToUpper())
            return true; 
    }
    return false;
}