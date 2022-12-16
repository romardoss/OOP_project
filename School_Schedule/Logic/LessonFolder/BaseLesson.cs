﻿using School_Schedule.DataBase.Services;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;
using System;

namespace School_Schedule.Logic.LessonFolder
{
    public abstract class BaseLesson
    {
        protected readonly LessonService LessonService = new LessonService();
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public BaseLesson(Subject subject, Teacher teacher, string timeStart, string timeEnd)
        {
            Subject = subject;
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

            LessonService.Add(this);
        }

        public virtual bool IsNow()
        {
            //кожен час переводиться у кількість хвилин
            int startMinutes = Start.Hour * 60 + Start.Minute;
            int endMinutes = End.Hour * 60 + End.Minute;
            DateTime now = DateTime.Now;
            int nowMinutes = now.Hour * 60 + now.Minute;
            return (nowMinutes > startMinutes) && (nowMinutes < endMinutes);
        }

        public abstract void ShowInfo();
        public abstract DayOfWeek GetDayOfWeek();
    }
}
