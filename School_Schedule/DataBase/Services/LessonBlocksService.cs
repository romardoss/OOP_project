using School_Schedule.DataBase.IServices;
using School_Schedule.Logic.LessonFolder;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace School_Schedule.DataBase.Services
{
    public class LessonBlocksService : ILessonBlocksService
    {
        public void Add(TextBlock block, Lesson lesson)
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

        public void DeleteByValue(Lesson lesson)
        {
            Delete(GetKeyByValue(lesson));
        }

        public TextBlock FindCurrent()
        {
            return DataBase.LessonBlocks.First(x => x.Value.IsNow()).Key;
        }

        public Dictionary<TextBlock, Lesson> Get()
        {
            return DataBase.LessonBlocks;
        }

        public TextBlock GetKeyByValue(Lesson lesson)
        {
            return DataBase.LessonBlocks.First(x => x.Value == lesson).Key;
        }

        public Lesson GetValue(TextBlock block)
        {
            if (!DataBase.LessonBlocks.TryGetValue(block, out Lesson lesson))
            {
                return null;
            }
            return lesson;
        }
    }
}
