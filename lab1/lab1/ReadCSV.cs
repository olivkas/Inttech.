using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace lab1
{
    class ReadCVS
    {
        public static List<string[]>ReadCsv(string file)
        {

            List<string[]> DataCsv = new List<string[]>();
            using (StreamReader streamReader = new StreamReader(file + ".csv"))
      //      using (StreamReader streamReader = new StreamReader(file))

            {

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Regex parser = new Regex("[,;]");
                    string[] readLine = parser.Split(line);
                    DataCsv.Add(readLine);
                }
            }
            
            return DataCsv;
            
        }
    }
}
