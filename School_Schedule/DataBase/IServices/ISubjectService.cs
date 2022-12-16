using System.Collections.Generic;
using School_Schedule.Logic.SubjectFolder;

namespace School_Schedule.DataBase
{
    internal interface ISubjectService
    {
        List<Subject> Get();
        List<string> GetNames();
        void Add(Subject subject);
        Subject GetByName(string name);
    }
}
