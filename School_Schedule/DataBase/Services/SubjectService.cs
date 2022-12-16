using School_Schedule.Logic.SubjectFolder;
using System.Collections.Generic;
using System.Linq;

namespace School_Schedule.DataBase.Services
{
    public class SubjectService : ISubjectService
    {
        public void Add(Subject subject)
        {
            DataBase.Subjects.Add(subject);
        }

        public List<Subject> Get()
        {
            return DataBase.Subjects;
        }

        public Subject GetByName(string name)
        {
            return DataBase.Subjects.First(x => x.Name == name);
        }

        public List<string> GetNames()
        {
            return DataBase.Subjects.Select(x => x.Name).ToList();
        }
    }
}
