using School_Schedule.Logic.SubjectFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Schedule.DataBase.Services
{
    public class SubjectService : ISubjectService
    {
        public DataBase DataBase { get; set; }

        public void Add(Subject subject)
        {
            DataBase.Subjects.Add(subject);
        }

        public List<Subject> Get()
        {
            return DataBase.Subjects;
        }

        public List<string> GetNames()
        {
            return DataBase.Subjects.Select(x => x.Name).ToList();
        }
    }
}
