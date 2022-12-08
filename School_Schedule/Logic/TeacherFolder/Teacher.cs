using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Schedule.Logic.TeacherFolder
{
    public abstract class Teacher
    {
        public static List<Teacher> AllTeachers = new List<Teacher>();
        public static List<string> AllNames = new List<string>();
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }

        public Teacher(string name, string surname = "", string patronymic = "", 
            string phone = "")
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            PhoneNumber = phone;
            AllNames.Add(name);
            AllTeachers.Add(this);
        }

        public abstract void ChangeInfo();
    }
}
