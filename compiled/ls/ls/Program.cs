using System;
using System.Collections.Generic;


using System.Linq;
using System.IO;


namespace ls
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            System.Console.WriteLine("");

            var DirsArr = Directory.GetDirectories(System.Environment.CurrentDirectory);
            System.Console.WriteLine(" " + DirsArr.Count().ToString() +" directories in " + System.Environment.CurrentDirectory);

            var filearr = Directory.GetFiles(System.Environment.CurrentDirectory);
            System.Console.WriteLine(" " + filearr.Count().ToString() +" files in " + System.Environment.CurrentDirectory);
            System.Console.WriteLine("");
            if(args.Length > 0)
            {
                if (args[0] == "-l")
                {

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    PrintList(DirsArr , false);
                    Console.ForegroundColor = ConsoleColor.White;
                    PrintList(filearr, true);
                }
                else{
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Print(DirsArr);
                    Console.ForegroundColor = ConsoleColor.White;
                    Print(filearr);
                }
            }
            else{
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Print(DirsArr);
                Console.ForegroundColor = ConsoleColor.White;
                Print(filearr);
            }



        }



       private static  void Print(string[] arr){

            foreach (var file in arr)
            {
                System.Console.Write(file.Replace(System.Environment.CurrentDirectory + @"\" , ""));
                System.Console.Write("   ");
            }
            System.Console.WriteLine("");
        }

       private  static void PrintList(string[] arr , bool isFile){
            foreach (var file in arr)
            {
                if(isFile){
                    FileInfo oFileInfo = new FileInfo(file);
                    DateTime dtCreationTime = oFileInfo.LastWriteTime;
                    System.Console.Write(oFileInfo.CreationTime.ToString("dd-MMM-yyyy") + "  " + dtCreationTime.ToString("dd-MMM-yyyy hh:mm:ss") + "  " + oFileInfo.Length.ToString() + "  " +  oFileInfo.Extension + "  ");
                }
                System.Console.WriteLine(file.Replace(System.Environment.CurrentDirectory + @"\" , ""));

            }
            System.Console.WriteLine("");
        }


    }
}