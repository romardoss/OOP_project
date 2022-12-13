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
        public string Name { get; set; }
        public string Type { get; set; }
        //"Тип предмету" - лек, прак, лаб, факульт, звичайний
        public string Homework { get; set; }
        public string Link { get; set; }

        public Subject(string name, string type, string homework, string link)
        {
            Name = name;
            Homework = homework;
            Type = type;
            Link = link;
            AllSubjects.Add(this);
        }
    }
}
