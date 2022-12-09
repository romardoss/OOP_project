using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;

namespace School_Schedule.Logic.LessonFolder
{
    public class Lesson
    {
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public static readonly List<Lesson> AllLessons = new List<Lesson>();

        public Lesson(Subject subject, Teacher teacher, string timeStart, string timeEnd, DayOfWeek day)
        {
            Subject = subject;
            DayOfWeek = day;
            Teacher = teacher;

            string[] timeComponents = timeStart.Split(':');
            int hours = int.Parse(timeComponents[0]);
            int minutes = int.Parse(timeComponents[1]);
            Start = new DateTime(DateTime.Today.Year,
                DateTime.Today.Month, DateTime.Today.Day, hours, minutes, 0);

            timeComponents = timeEnd.Split(':');
            hours = int.Parse(timeComponents[0]);
            minutes = int.Parse(timeComponents[1]);
            End = new DateTime(DateTime.Today.Year,
                DateTime.Today.Month, DateTime.Today.Day, hours, minutes, 0);

            AllLessons.Add(this);
        }

        public virtual bool IsNow()
        {
            return (DateTime.Now > Start) && (DateTime.Now < End) 
                && DateTime.Today.DayOfWeek == DayOfWeek;
        }

        public void ShowInfo()
        {
            LessonShowInfo info = new LessonShowInfo(this);
            info.ShowDialog();
        }

    }
}
