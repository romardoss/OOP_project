using School_Schedule.DataBase.Services;

namespace School_Schedule.Logic.SubjectFolder
{
    public class Subject
    {
        private readonly SubjectService SubjectService = new SubjectService();
        public string Name { get; }
        public string Type { get; }
        //"Тип предмету" - лек, прак, лаб, факульт, звичайний
        public string Homework { get; }
        public string Link { get; }
        public int ID { get; }

        private static int newID = 0;
        public int NewID
        {
            get
            {
                newID++;
                return newID;
            }
            set { }
        }


        public Subject(string name, string type, string homework, string link)
        {
            Name = name;
            Homework = homework;
            Type = type;
            Link = link;
            SubjectService.Add(this);
            ID = NewID;
        }
    }
}
