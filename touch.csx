using System.IO;
using System.Linq;

List<string> currentfolder = new List<string>();

var workingfolder = Env.ScriptArgs[Env.ScriptArgs.Count -1];

var  ArgsArray = Env.ScriptArgs.Take(Env.ScriptArgs.Count() - 1).ToArray();


foreach (var item in ArgsArray)
{
    if (item == "..")
    {

        RemoveLast(currentfolder);
        continue;
    }


    if (item.Contains("."))
    {
        if (currentfolder.Count == 0)
            File.Create(Join(currentfolder) + @"\" + item);
        else
            File.Create(Join(currentfolder) + @"\" + item);
    }
    else
    {
        currentfolder.Add(item);
        Directory.CreateDirectory(Join(currentfolder));
    }

}
System.Console.WriteLine("files created");
void RemoveLast(List<string> list)
{
    list.RemoveAt(list.Count - 1);
}

string Join(List<string> list)
{
    var retval =  workingfolder + @"\" + String.Join( @"\", list.ToArray());
    return retval;
}