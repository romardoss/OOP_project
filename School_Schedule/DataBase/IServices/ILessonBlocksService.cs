using School_Schedule.Logic.LessonFolder;
using System.Collections.Generic;
using System.Windows.Controls;

namespace School_Schedule.DataBase.IServices
{
    public interface ILessonBlocksService
    {
        void Add(TextBlock block, BaseLesson lesson);
        Dictionary<TextBlock, BaseLesson> Get();
        BaseLesson GetValue(TextBlock block);
        TextBlock GetKeyByValue(BaseLesson lesson);
        TextBlock FindCurrent();
        bool ContainsKey(TextBlock block);
        void Delete(TextBlock block);
        void DeleteByValue(BaseLesson lesson);
        void DeleteOneTimeLessonsThatAreGone();
        List<TextBlock> GetLessonsThatAreNotCurrentNow();
    }
}
