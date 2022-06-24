using System;
var processToKill = Env.ScriptArgs[0];
System.Console.WriteLine(processToKill);
System.Console.WriteLine(System.Diagnostics.Process.GetProcesses().Length);
foreach (var process in System.Diagnostics.Process.GetProcessesByName(processToKill))
{
    process.Kill();
}
