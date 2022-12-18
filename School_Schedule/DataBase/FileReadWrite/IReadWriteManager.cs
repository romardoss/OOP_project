using School_Schedule.Logic.LessonFolder;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace School_Schedule.DataBase.FileReadWrite
{
    public interface IReadWriteManager
    {
        void WriteTeachers();
        void WriteSubjects();
        void WriteLessons();
        void WriteLessonBlocks();
        List<Teacher> ReadTeachers();
        List<Subject> ReadSubjects();
        List<BaseLesson> ReadLessons();
        Dictionary<TextBlock, BaseLesson> ReadLessonBlocks();
        void Save();
        void Import();
    }
}
