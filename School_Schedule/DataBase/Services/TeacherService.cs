﻿using System.Collections.Generic;
using System.Linq;
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
    }
}