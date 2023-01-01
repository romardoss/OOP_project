using School_Schedule.DataBase.IServices;
using School_Schedule.Logic.LessonFolder;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace School_Schedule.DataBase.Services
{
    public class DeleteService : IDeleteService
    {
        public static List<TextBlock> QueueToDeleteBlocks = new List<TextBlock>();

        public void Add(TextBlock block)
        {
            QueueToDeleteBlocks.Add(block);
        }

        public void Clean()
        {
            QueueToDeleteBlocks = new List<TextBlock>();
        }

        public void Delete(TextBlock block)
        {
            QueueToDeleteBlocks.Remove(block);
        }

        public List<TextBlock> GetList()
        {
            return QueueToDeleteBlocks;
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
