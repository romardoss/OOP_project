using School_Schedule.Logic.LessonFolder;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;
using System.Collections.Generic;
using System.Windows.Controls;

namespace School_Schedule.DataBase.FileReadWrite
{
    public interface IReadWriteManager
    {
        void WriteTeachers();
        void WriteSubjects();
        void WriteLessons();
        List<Teacher> ReadTeachers();
        List<Subject> ReadSubjects();
        List<BaseLesson> ReadLessons();
        void Save();
        void Import();
    }
}
