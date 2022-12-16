using School_Schedule.Logic.LessonFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Schedule.DataBase.Services
{
    public class LessonService : ILessonService
    {
        public void Add(Lesson lesson)
        {
            DataBase.Lessons.Add(lesson);
        }

        public void Delete(Lesson lesson)
        {
            DataBase.Lessons.Remove(lesson);
        }

        public List<Lesson> Get()
        {
            return DataBase.Lessons;
        }
    }
}
