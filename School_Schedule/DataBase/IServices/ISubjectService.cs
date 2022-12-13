using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Schedule.Logic.LessonFolder;
using School_Schedule.Logic.ScheduleFolder;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;

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
