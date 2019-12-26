using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class Process
    {
        public static void Start(string inputFile, string outputFile = null, string format = null)
     //   public static void Start()
        {
     //       string inputFile = @"E:\Univer\4 курс\7 сем\Интернет технологии\lab1\lab1\lab1\list.csv";
     //       string outputFile = @"E:\Univer\4 курс\7 сем\Интернет технологии\lab1\lab1\lab1\out";
     //       string format = "xlsx";

     
            List<string[]> data = ReadCVS.ReadCsv(inputFile);

            Group group = new Group(data);

            if (outputFile != null)
            {
                if (format.ToUpper() == "JSON")
                {
                    SaveJson.SaveGroupList(group, outputFile);
                    Console.WriteLine("Saved to JSON.");
                }
                else if (format.ToUpper() == "XLSX")
                {
                    SaveExcel.SaveGroupList(group, outputFile);
                    Console.WriteLine("Saved to XLSX.");
                }
            }
        }
    }
}
