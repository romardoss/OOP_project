using School_Schedule.DataBase.Services;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;
using System;

namespace School_Schedule.Logic.LessonFolder
{
    public abstract class BaseLesson
    {
        public int SubjectID { get; }
        public int TeacherID { get; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public BaseLesson(Subject subject, Teacher teacher, string startTime, string endTime)
        {
            SubjectID = subject.ID;
            TeacherID = teacher.ID;
            StartTime = startTime;
            EndTime = endTime;

            LessonService LessonService = new LessonService();
            LessonService.Add(this);
        }

        public Teacher GetTeacher()
        {
            TeacherService teacherService = new TeacherService();
            return teacherService.GetTeacherByID(TeacherID);
        }

        public Subject GetSubject()
        {
            SubjectService subjectService = new SubjectService();
            return subjectService.GetById(SubjectID);
        }

        public virtual DateTime GetStartTime()
        {
            string[] timeComponents = StartTime.Split(':');
            int hours = int.Parse(timeComponents[0]);
            int minutes = int.Parse(timeComponents[1]);
            return new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, hours, minutes, 0);
        }

        public virtual DateTime GetEndTime()
        {
            var timeComponents = EndTime.Split(':');
            var hours = int.Parse(timeComponents[0]);
            var minutes = int.Parse(timeComponents[1]);
            return new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, hours, minutes, 0);
        }

        public virtual bool IsNow()
        {
            //кожен час переводиться у кількість хвилин
            int startMinutes = GetStartTime().Hour * 60 + GetStartTime().Minute;
            int endMinutes = GetEndTime().Hour * 60 + GetEndTime().Minute;
            DateTime now = DateTime.Now;
            int nowMinutes = now.Hour * 60 + now.Minute;
            return (nowMinutes > startMinutes) && (nowMinutes < endMinutes);
        }

        public abstract void ShowInfo();
        public abstract DayOfWeek GetDayOfWeek();
    }
}
