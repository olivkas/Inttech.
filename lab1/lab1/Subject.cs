using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace lab1
{
    public class Subject
    {
        public string name { get; set; }
        public double mark { get; set; }
        public Subject(string name, double mark)
        {
            this.name = name;
            this.mark = mark;
        }
    }
}
