using System;

Console.WriteLine(Env.ScriptArgs[0]); 


DateTime today = DateTime.Now;
DateTime threedayfromnow = DateTime.Now.AddDays(3);

TimeSpan timespan = (threedayfromnow - today );
Console.WriteLine(timespan.Days);

