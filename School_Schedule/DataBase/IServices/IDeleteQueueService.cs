using System.Collections.Generic;
using System.Windows.Controls;

namespace School_Schedule.DataBase.IServices
{
    internal interface IDeleteQueueService
    {
        void Add(TextBlock block);
        List<TextBlock> GetList();
        void Delete(TextBlock block);
        void Clean();
    }
}
