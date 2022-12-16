using School_Schedule.Logic.LessonFolder;
using System.Collections.Generic;

namespace School_Schedule.DataBase.Services
{
    public class LessonService : ILessonService
    {
        public void Add(BaseLesson lesson)
        {
            DataBase.Lessons.Add(lesson);
        }

        public void Delete(BaseLesson lesson)
        {
            DataBase.Lessons.Remove(lesson);
        }

        public List<BaseLesson> Get()
        {
            return DataBase.Lessons;
        }
    }
}
