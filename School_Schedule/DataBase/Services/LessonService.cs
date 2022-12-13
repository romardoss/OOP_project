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
        public DataBase DataBase { get; set; }

        public void Add(Lesson lesson)
        {
            DataBase.Lessons.Add(lesson);
        }

        public List<Lesson> Get()
        {
            return DataBase.Lessons;
        }
    }
}
