using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Schedule.Logic.LessonFolder;
using School_Schedule.Logic.ScheduleFolder;
using School_Schedule.Logic.SubjectFolder;
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
        //List<string> GetPhoneNumber();
        //List<string> GetEmails();
        //List<string> GetAdditionalInfo();
        //List<int> GetTeachers();
    }
}
