using System.Collections.Generic;
using School_Schedule.Logic.LessonFolder;

namespace School_Schedule.DataBase
{
    public interface ILessonService
    {
        List<BaseLesson> Get();
        List<RegularLesson> GetRegular();
        List<OneTimeLesson> GetOneTime();
        void Add(BaseLesson lesson);
        void Delete (BaseLesson lesson);
    }
}
