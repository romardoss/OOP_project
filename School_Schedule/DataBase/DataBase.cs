using System.Collections.Generic;
using System.Windows.Controls;
using School_Schedule.Logic.LessonFolder;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;

namespace School_Schedule.DataBase
{
    public class DataBase
    {
        public static List<Teacher> Teachers = new List<Teacher>();
        public static List<Subject> Subjects = new List<Subject>();
        public static List<Lesson> Lessons = new List<Lesson>();
        public static Dictionary<TextBlock, Lesson> LessonBlocks = new Dictionary<TextBlock, Lesson>();
        public static List<TextBlock> QueueToDeleteBlocks = new List<TextBlock>();
    }
}
