using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace lab1
{
    public class Student
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public List<Subject> subjects { get; set; }
        public double totalScore;


        public Student(string surname, string name, string patronymic)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            subjects = new List<Subject>();
        }

        public void AverageMark()
        {
             totalScore = 0;

            foreach(Subject sub in subjects)
            {
                totalScore += sub.mark;
            }

            totalScore /= subjects.Count;
            
        
        }

        public void AddSubj(Subject subject)
        {
            subjects.Add(subject);
            AverageMark();
        }

    }
}
