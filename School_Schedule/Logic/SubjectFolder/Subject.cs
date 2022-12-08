using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Schedule.Logic.SubjectFolder
{
    public class Subject
    {
        public static List<Subject> AllSubjects = new List<Subject>();
        public static List<string> AllNames = new List<string>();
        //треба зробити так, щоб цього списку не було. можна використовувати
        //пошук за лямбдою
        public string Name { get; set; }
        public string Homework { get; set; }

        public Subject(string name, string homework)
        {
            Name = name;
            Homework = homework;
            AllSubjects.Add(this);
            AllNames.Add(Name);
        }
    }
}
