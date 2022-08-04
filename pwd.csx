#r "System.Windows.Forms"


using System.Windows.Forms;
using System.Threading;



System.Console.WriteLine("");
// Read each line of the file into a string array. Each element
// of the array is one line of the file.

var content = Env.ScriptArgs[0];
  var thread = new Thread(() => {
        Clipboard.SetText(content);
        System.Console.WriteLine(content);
    });
    thread.SetApartmentState(ApartmentState.STA);
    thread.IsBackground = false;
    thread.Start();
    thread.Join();