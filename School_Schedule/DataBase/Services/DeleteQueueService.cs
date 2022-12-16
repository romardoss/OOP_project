using School_Schedule.DataBase.IServices;
using System.Collections.Generic;
using System.Windows.Controls;

namespace School_Schedule.DataBase.Services
{
    internal class DeleteQueueService : IDeleteQueueService
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
    }
}
