﻿using School_Schedule.DataBase.Services;

namespace School_Schedule.Logic.SubjectFolder
{
    public class Subject
    {
        private readonly SubjectService SubjectService = new SubjectService();
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
            SubjectService.Add(this);
        }
    }
}
