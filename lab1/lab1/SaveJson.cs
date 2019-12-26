using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace lab1
{
    class SaveJson
    {
        public static void SaveGroupList(Group group, string file)
        {

            try
            {
                string json = JsonConvert.SerializeObject(group);
                File.WriteAllText(file + ".json", json);
            }
            catch 
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
