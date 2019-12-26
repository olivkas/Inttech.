using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
                if (args.Length == 4)
                {
                    Process.Start(args[1], args[2], args[3]);
                }
                else
                {
                    Console.WriteLine("Error!!!, Please, check your file name, or file type, or number of arguments)");
                }
        }

    }

}

    
    



