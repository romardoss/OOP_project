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
    public interface ILessonService
    {
        List<Lesson> Get();
        void Add(Lesson lesson);
        void Delete (Lesson lesson);
    }
}
