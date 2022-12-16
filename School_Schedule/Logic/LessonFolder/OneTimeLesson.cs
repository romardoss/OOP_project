using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;
using System;

namespace School_Schedule.Logic.LessonFolder
{
    public class OneTimeLesson : BaseLesson
    {
        public DateTime Date { get; set; }

        public OneTimeLesson(Subject subject, Teacher teacher, string timeStart, 
            string timeEnd, DateTime date)
            : base(subject, teacher, timeStart, timeEnd)
        {
            //string[] dateComponents = date.Split('.');
            //int day = int.Parse(dateComponents[0]);
            //int month = int.Parse(dateComponents[1]);
            //int year = int.Parse(dateComponents[2]);
            //Date = new DateTime(year, month, day, 0, 0, 0);
            Date = date;
        }

        public override bool IsNow()
        {
            return (DateTime.Now > Start) && (DateTime.Now < End)
                && (DateTime.Today == Date);
        }

        public bool IsTimeToDelete()
        {
            return DateTime.Now > End;
        }

        public override void ShowInfo()
        {
            LessonShowInfo info = new LessonShowInfo(this);
            info.ShowDialog();
        }

        public override DayOfWeek GetDayOfWeek()
        {
            return Date.DayOfWeek;
        }
    }
}
