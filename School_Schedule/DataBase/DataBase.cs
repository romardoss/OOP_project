using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        public static Dictionary<TextBlock, BaseLesson> LessonBlocks = new Dictionary<TextBlock, BaseLesson>();
        public static List<TextBlock> QueueToDeleteBlocks = new List<TextBlock>();

        public void UpdateDatabase()
        {
            //Teachers = ReadWriteManager.ReadTeachers();
            //Subjects = ReadWriteManager.ReadSubjects();
            //Lessons = ReadWriteManager.ReadLessons();
            try
            {
                Teachers = ReadWriteManager.ReadTeachers();
            }
            catch(Exception e)
            {
                MessageBox.Show("Teacher read error");
                MessageBox.Show(e.Message);
            }
            try
            {
                Subjects = ReadWriteManager.ReadSubjects();
            }
            catch(Exception e)
            {
                MessageBox.Show("Subjects read error");
                MessageBox.Show(e.Message);
            }
            try
            {
                Lessons = ReadWriteManager.ReadLessons();
            }
            catch (Exception e)
            {
                MessageBox.Show("Lessons read error");
                MessageBox.Show(e.Message);
            }

        }
    }
}
