using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Schedule.Logic.TeacherFolder
{
    internal abstract class Teacher
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }

        public Teacher(string name, string surname, string patronymic, 
            string phone, string subject)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            PhoneNumber = phone;
            Subject = subject;
        }

        public abstract void ChangeInfo();
    }
}
