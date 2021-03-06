﻿using System;
using System.Collections.Generic;

namespace cat
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            System.Console.WriteLine("");
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(args[0]);

            if (args.Length > 1  && args[1] == "-l")
            {

                for (int i = 0; i < lines.Length; i++)
                {
                    var line  = lines[i];
                    Console.WriteLine((i + 1).ToString() +  ":\t" + line);
                }

            }else{

                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    Console.WriteLine(line);
                }
            }


        }
    }
}