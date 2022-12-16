using System.Collections.Generic;
using School_Schedule.Logic.LessonFolder;

namespace School_Schedule.DataBase
{
    public interface ILessonService
    {
        List<BaseLesson> Get();
        void Add(BaseLesson lesson);
        void Delete (BaseLesson lesson);
    }
}
