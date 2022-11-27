using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Schedule.Logic.SubjectFolder
{
    internal class Subject
    {
        public static List<Subject> AllSubjects = new List<Subject>();
        public static List<string> AllNames = new List<string>();
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Homework { get; set; }

        public Subject(string name, string teacher, string homework)
        {
            Name = name;
            Teacher = teacher;
            Homework = homework;
            AllSubjects.Add(this);
            AllNames.Add(Name);
        }
    }
}
