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

        public List<OneTimeLesson> GetOneTime()
        {
            List <OneTimeLesson> list = new List<OneTimeLesson>();
            foreach(var item in Get())
            {
                if(item.GetType() == typeof(OneTimeLesson))
                {
                    list.Add((OneTimeLesson)item);
                }
            }
            return list;
        }

        public List<RegularLesson> GetRegular()
        {
            List<RegularLesson> list = new List<RegularLesson>();
            foreach (var item in Get())
            {
                if (item.GetType() == typeof(RegularLesson))
                {
                    list.Add((RegularLesson)item);
                }
            }
            return list;
        }
    }
}
