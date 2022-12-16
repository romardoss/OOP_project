using School_Schedule.DataBase.IServices;
using School_Schedule.Logic.LessonFolder;
using System.Collections.Generic;
using System.Windows.Controls;

namespace School_Schedule.DataBase.Services
{
    public class DeleteService : IDeleteService
    {
        public void Add(TextBlock block)
        {
            DataBase.QueueToDeleteBlocks.Add(block);
        }

        public void Clean()
        {
            DataBase.QueueToDeleteBlocks = new List<TextBlock>();
        }

        public void Delete(TextBlock block)
        {
            DataBase.QueueToDeleteBlocks.Remove(block);
        }

        public List<TextBlock> GetList()
        {
            return DataBase.QueueToDeleteBlocks;
        }

        public void MoveToTrash(BaseLesson lesson)
        {
            LessonBlocksService lessonBlocksService = new LessonBlocksService();
            Add(lessonBlocksService.GetKeyByValue(lesson));
            lessonBlocksService.DeleteByValue(lesson);
        }

        public void MoveToTrash(TextBlock block)
        {
            LessonBlocksService lessonBlocksService = new LessonBlocksService();
            Add(block);
            lessonBlocksService.Delete(block);
        }
    }
}
