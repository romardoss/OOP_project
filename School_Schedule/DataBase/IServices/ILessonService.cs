using System.Collections.Generic;
using School_Schedule.Logic.LessonFolder;

namespace School_Schedule.DataBase
{
    public interface ILessonService
    {
        List<Lesson> Get();
        void Add(Lesson lesson);
        void Delete (Lesson lesson);
    }
}
