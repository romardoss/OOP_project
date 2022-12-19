using System;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;

namespace School_Schedule.Logic.LessonFolder
{
    public class RegularLesson : BaseLesson
    {
        public DayOfWeek DayOfWeek { get; }

        public RegularLesson(Subject subject, Teacher teacher, string timeStart, 
            string timeEnd, DayOfWeek dayOfWeek)
            : base(subject, teacher, timeStart, timeEnd)
        {
            DayOfWeek = dayOfWeek;
        }

        public override bool IsNow()
        {
            return base.IsNow() && DateTime.Today.DayOfWeek == DayOfWeek;
        }

        public override void ShowInfo()
        {
            LessonShowInfo info = new LessonShowInfo(this);
            info.ShowDialog();
        }

        public override DayOfWeek GetDayOfWeek()
        {
            return DayOfWeek;
        }
    }
}
