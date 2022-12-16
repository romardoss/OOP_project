using School_Schedule.DataBase.IServices;
using School_Schedule.Logic.LessonFolder;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace School_Schedule.DataBase.Services
{
    public class LessonBlocksService : ILessonBlocksService
    {
        public void Add(TextBlock block, BaseLesson lesson)
        {
            DataBase.LessonBlocks.Add(block, lesson);
        }

        public bool ContainsKey(TextBlock block)
        {
            return DataBase.LessonBlocks.ContainsKey(block);
        }

        public void Delete(TextBlock block)
        {
            LessonService lessonService = new LessonService();
            lessonService.Delete(GetValue(block));
            DataBase.LessonBlocks.Remove(block);
        }

        public void DeleteByValue(BaseLesson lesson)
        {
            Delete(GetKeyByValue(lesson));
        }

        public TextBlock FindCurrent()
        {
            return DataBase.LessonBlocks.First(x => x.Value.IsNow()).Key;
        }

        public Dictionary<TextBlock, BaseLesson> Get()
        {
            return DataBase.LessonBlocks;
        }

        public TextBlock GetKeyByValue(BaseLesson lesson)
        {
            return DataBase.LessonBlocks.First(x => x.Value == lesson).Key;
        }

        public BaseLesson GetValue(TextBlock block)
        {
            if (!DataBase.LessonBlocks.TryGetValue(block, out BaseLesson lesson))
            {
                return null;
            }
            return lesson;
        }

        public void DeleteOneTimeLessonsThatAreGone()
        {
            LessonService lessonService = new LessonService();
            DeleteService deleteService = new DeleteService();
            List<OneTimeLesson> itemsToDelete = new List<OneTimeLesson>();
            //перебирається кожен урок
            foreach (BaseLesson lesson in lessonService.Get())
            {
                //відбираються лише одноразові уроки
                if (lesson.GetType() == typeof(OneTimeLesson))
                {
                    OneTimeLesson oneTimeLesson = (OneTimeLesson)lesson;
                    //додається в чергу на видалення, якщо урок уже минув
                    if (oneTimeLesson.IsTimeToDelete())
                    {
                        //занесення елементів для видалення в список
                        itemsToDelete.Add(oneTimeLesson);
                    }
                }
            }
            foreach(OneTimeLesson lesson in itemsToDelete)
            {
                //переміщено в кошик
                deleteService.MoveToTrash(lesson);
            }
            //обов'язково потрібно переміщати в кошик окремо, бо тоді видаляються уроки
            //з бази даних і цикл foreach (BaseLesson lesson in lessonService.Get()) крашиться
        }

        public List<TextBlock> GetLessonsThatIsNotCurrentNow()
        {
            var temp = Get().Values.Where(x => !x.IsNow()).ToList();
            List<TextBlock> result = new List<TextBlock>();
            foreach (var item in temp)
            {
                result.Add(GetKeyByValue(item));
            }
            return result;
        }
    }
}
