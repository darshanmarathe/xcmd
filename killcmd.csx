System.Console.WriteLine(System.Diagnostics.Process.GetProcesses().Length);
foreach (var process in System.Diagnostics.Process.GetProcessesByName("cmd"))
{
    process.Kill();
}
