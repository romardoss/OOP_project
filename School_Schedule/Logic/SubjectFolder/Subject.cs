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
        //Добавив поле "Тип предмету" - лек, прак, лаб, факульт, звичайний
        public string Name { get; set; }
        public string Type { get; set; }
        public string Homework { get; set; }
        public string Link { get; set; }

        public Subject(string name, string type, string homework, string link)
        {
            Name = name;
            Homework = homework;
            Type = type;
            Link = link;
            AllSubjects.Add(this);
            AllNames.Add(Name);
        }
    }
}
