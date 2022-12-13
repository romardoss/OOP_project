using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Schedule.Logic.TeacherFolder
{
    internal class PrivateTeacher : Teacher
    {
        public string Address { get; set; }
        public int PriceOfLesson { get; set; }

        public PrivateTeacher(string name, string surname, string patronymic, 
            string phone, string address, int price, string additionalInfo) 
            : base(name, surname, patronymic, phone, additionalInfo)
        {
            Address = address;
            PriceOfLesson = price;
        }

        public override void ChangeInfo()
        {
            
        }
    }
}
