using School_Schedule.Logic.LessonFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace School_Schedule.DataBase.IServices
{
    public interface ILessonBlocksService
    {
        void Add(TextBlock block, Lesson lesson);
        Dictionary<TextBlock, Lesson> Get();
        Lesson GetValue(TextBlock block);
        TextBlock GetKeyByValue(Lesson lesson);
        TextBlock FindCurrent();
        bool ContainsKey(TextBlock block);
        void Delete(TextBlock block);
        void DeleteByValue(Lesson lesson);
    }
}
