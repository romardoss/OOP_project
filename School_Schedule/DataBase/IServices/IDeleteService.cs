using System.Collections.Generic;
using System.Windows.Controls;
using School_Schedule.Logic.LessonFolder;

namespace School_Schedule.DataBase.IServices
{
    internal interface IDeleteService
    {
        void Add(TextBlock block);
        List<TextBlock> GetList();
        void Delete(TextBlock block);
        void Clean();
        void MoveToTrash(BaseLesson lesson);
        void MoveToTrash(TextBlock block);
    }
}
