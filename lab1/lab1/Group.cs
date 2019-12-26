using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace lab1
{
    class Group
    {
        public string[] header { get; set; }
        public List<Student> students { get; set; }
        public Dictionary<string, double> subjects { get; set; }
        public Dictionary<string, double> averageMarks { get; set; }

        public Group(List<string[]> data)
        {
         
            header = data[0];
            data.Remove(data[0]);

            subjects = new Dictionary<string, double>();
            averageMarks = new Dictionary<string, double>();
            students = new List<Student>();


            for (int i = 3; i < header.Length; i++)
            {
                subjects.Add(header[i], 0);
                averageMarks.Add(header[i], 0);
            }

            subjects.Add("Average", 0);
            averageMarks.Add("Average", 0);

            foreach (string[] line in data)
            {
                Student student = new Student(line[0], line[1], line[2]);

                for (int i = 3; i < header.Length; i++)
                {
                    Subject subj = new Subject(header[i], double.Parse(line[i]));
                    student.AddSubj(subj);

                    subjects[header[i]] += double.Parse(line[i]);
                    averageMarks[header[i]] = subjects[header[i]] / (students.Count + 1);
                }
                
                subjects["Average"] += student.totalScore;
                averageMarks["Average"] = subjects["Average"] / (students.Count + 1);

                students.Add(student);
            }
        }

 
    }
}
