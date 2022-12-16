using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
