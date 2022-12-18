using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using School_Schedule.Logic.TeacherFolder;

namespace School_Schedule.DataBase.Services
{
    public class TeacherService : ITeacherService
    {
        public void Add(Teacher teacher)
        {
            DataBase.Teachers.Add(teacher);
        }

        public List<Teacher> Get()
        {
            return DataBase.Teachers;
        }

        public Teacher GetByName(string name)
        {
            return DataBase.Teachers.First(x => x.Name == name);
        }

        public List<string> GetNames()
        {
            return DataBase.Teachers.Select(x => x.Name).ToList();
        }

        public List<string> GetPatronymics()
        {
            return DataBase.Teachers.Select(x => x.Patronymic).ToList();
        }

        public List<string> GetSurnames()
        {
            return DataBase.Teachers.Select(x => x.Surname).ToList();
        }

        public List<PrivateTeacher> GetPrivateTeachers()
        {
            List<PrivateTeacher> list = new List<PrivateTeacher>();
            foreach (var item in Get())
            {
                if (item.GetType() == typeof(PrivateTeacher))
                {
                    list.Add((PrivateTeacher)item);
                }
            }
            return list;
        }

        public List<SchoolTeacher> GetSchoolTeachers()
        {
            List<SchoolTeacher> list = new List<SchoolTeacher>();

            foreach (var teacher in Get())
            {
                if (teacher.GetType() == typeof(SchoolTeacher))
                {
                    list.Add((SchoolTeacher)teacher);
                }
            }
            return list;
        }

    }
}
