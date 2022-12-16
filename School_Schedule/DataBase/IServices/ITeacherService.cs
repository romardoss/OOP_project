using System.Collections.Generic;
using School_Schedule.Logic.TeacherFolder;

namespace School_Schedule.DataBase
{
    public interface ITeacherService
    {
        List<Teacher> Get();
        List<string> GetNames();
        List<string> GetSurnames();
        List<string> GetPatronymics();
        Teacher GetByName(string name);
        void Add(Teacher teacher);
    }
}
