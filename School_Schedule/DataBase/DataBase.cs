using System.Collections.Generic;
using School_Schedule.DataBase.FileReadWrite;
using School_Schedule.Logic.LessonFolder;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;

namespace School_Schedule.DataBase
{
    public class DataBase
    {
        private readonly ReadWriteManager ReadWriteManager = new ReadWriteManager();

        public static List<Teacher> Teachers = new List<Teacher>();
        public static List<Subject> Subjects = new List<Subject>();
        public static List<BaseLesson> Lessons = new List<BaseLesson>();

        public void UpdateDatabase()
        {
            Teachers = ReadWriteManager.ReadTeachers();
            Subjects = ReadWriteManager.ReadSubjects();
            Lessons = ReadWriteManager.ReadLessons();
        }
    }
}
