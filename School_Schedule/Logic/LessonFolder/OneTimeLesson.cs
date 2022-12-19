using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;
using System;

namespace School_Schedule.Logic.LessonFolder
{
    public class OneTimeLesson : BaseLesson
    {
        public OneTimeLesson(Subject subject, Teacher teacher, string timeStart, 
            string timeEnd, DateTime date)
            : base(subject, teacher, timeStart, timeEnd)
        {
            Start = new DateTime(date.Year, date.Month, date.Day, Start.Hour, Start.Minute, 0);
            End = new DateTime(date.Year, date.Month, date.Day, End.Hour, End.Minute, 0);
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
            return Start.DayOfWeek;
        }

        public override bool IsNow()
        {
            return (DateTime.Now > Start) && (DateTime.Now < End);
        }
    }
}
