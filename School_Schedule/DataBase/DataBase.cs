﻿using System.Collections.Generic;
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
        public static List<BaseLesson> Lessons = new List<BaseLesson>();
        public static Dictionary<TextBlock, BaseLesson> LessonBlocks = new Dictionary<TextBlock, BaseLesson>();
        public static List<TextBlock> QueueToDeleteBlocks = new List<TextBlock>();
    }
}
