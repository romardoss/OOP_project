using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Schedule.Logic.TeacherFolder
{
    internal class SchoolTeacher:Teacher
    {
        public string OfficeNumber { get; set; }

        public SchoolTeacher(string name, string surname, string patronymic, 
            string phone, string subject, string officeNumber)
            : base(name, surname, patronymic, phone, subject)
        {
            OfficeNumber = officeNumber;
        }

        public override void ChangeInfo()
        {
            
        }
    }
}
