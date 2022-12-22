using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;
using System;
using System.Collections.Generic;
using System.Windows;

namespace School_Schedule.Logic.LessonFolder
{
    public class OneTimeLesson : BaseLesson
    {
        public OneTimeLesson(Subject subject, Teacher teacher, string timeStart, 
            string timeEnd, DateTime date)
            : base(subject, teacher, timeStart, timeEnd)
        {
            StartTime = String.Join(" ", date.Year, date.Month, date.Day, base.GetStartTime().Hour, base.GetStartTime().Minute, 0).ToString();
            EndTime = String.Join(" ", date.Year, date.Month, date.Day, base.GetEndTime().Hour, base.GetEndTime().Minute, 0).ToString();
        }

        public override DateTime GetStartTime()
        {
            string[] timeComponentsString = StartTime.Split(' ');
            List<int> timeComponents = new List<int>();
            foreach (string comp in timeComponentsString)
            {
                timeComponents.Add(int.Parse(comp));
            }
            return new DateTime(timeComponents[0], timeComponents[1], timeComponents[2], timeComponents[3], timeComponents[4], 0);
        }

        public override DateTime GetEndTime()
        {
            string[] timeComponentsString = EndTime.Split(' ');
            List<int> timeComponents = new List<int>();
            foreach (string comp in timeComponentsString)
            {
                timeComponents.Add(int.Parse(comp));
            }
            return new DateTime(timeComponents[0], timeComponents[1], timeComponents[2], timeComponents[3], timeComponents[4], 0);
        }

        public bool IsTimeToDelete()
        {
            return DateTime.Now > GetEndTime();
        }

        public override void ShowInfo()
        {
            LessonShowInfo info = new LessonShowInfo(this);
            info.ShowDialog();
        }

        public override DayOfWeek GetDayOfWeek()
        {
            return GetStartTime().DayOfWeek;
        }

        public override bool IsNow()
        {
            return (DateTime.Now > GetStartTime()) && (DateTime.Now < GetEndTime());
        }
    }
}
