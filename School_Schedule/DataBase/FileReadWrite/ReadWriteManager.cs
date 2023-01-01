using School_Schedule.DataBase.Services;
using School_Schedule.Logic.LessonFolder;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text;

namespace School_Schedule.DataBase.FileReadWrite
{
    internal class ReadWriteManager : IReadWriteManager
    {
        private readonly TeacherService teacherService = new TeacherService();
        private readonly SubjectService subjectService = new SubjectService();
        private readonly LessonBlocksService lessonBlocksService = new LessonBlocksService();
        private readonly LessonService lessonService = new LessonService();

        private readonly string PrivateTeacherFileName = "PrivateTeachersData.json";
        private readonly string SchoolTeacherFileName = "SchoolTeachersData.json";
        private readonly string SubjectFileName = "SubjectData.json";
        private readonly string RegularLessonFileName = "RegularLessonData.csv";
        private readonly string OneTimeLessonFileName = "OneTimeLessonData.csv";

        /*public List<BaseLesson> ReadLessons()
        {
            string pathRegular = GetPath(RegularLessonFileName);
            List<RegularLesson> regularList = new List<RegularLesson>();
            string pathOneTime = GetPath(OneTimeLessonFileName);
            List<OneTimeLesson> oneTimeList = new List<OneTimeLesson>();
            List<BaseLesson> allLessons = new List<BaseLesson>();

            if (File.Exists(pathRegular))
            {
                try
                {
                    string inputText = File.ReadAllText(pathRegular);
                    regularList = JsonConvert.DeserializeObject<List<RegularLesson>>(inputText);

                    //string jsonString = File.ReadAllText(pathRegular);
                    //regularList = System.Text.Json.JsonSerializer.Deserialize<List<RegularLesson>>(jsonString);
                }
                catch(Exception e)
                {
                    MessageBox.Show("Problems with regular lesson reading");
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Unable to find a file with data");
            }

            if (File.Exists(pathOneTime))
            {
                try
                {
                    string inputText = File.ReadAllText(pathOneTime);
                    oneTimeList = JsonConvert.DeserializeObject<List<OneTimeLesson>>(inputText);

                    //string jsonString = File.ReadAllText(pathOneTime);
                    //oneTimeList = System.Text.Json.JsonSerializer.Deserialize<List<OneTimeLesson>>(jsonString);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Problems with one time lesson reading");
                    MessageBox.Show(e.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Unable to find a file with data");
            }
            allLessons = allLessons.Concat(oneTimeList).Concat(regularList).ToList();
            return allLessons;
        }*/

        public List<BaseLesson> ReadLessons()
        {
            var reader = new StreamReader(GetPath(RegularLessonFileName));
            List<RegularLesson> regularList = new List<RegularLesson>();
            List<OneTimeLesson> oneTimeList = new List<OneTimeLesson>();
            List<BaseLesson> lessons = new List<BaseLesson>();
            int subjectID;
            int teacherID;
            DayOfWeek dayOfWeek;
            string startTime;
            string endTime;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                subjectID = int.Parse(values[0]);
                Subject subject = subjectService.GetById(subjectID);
                teacherID = int.Parse(values[1]);
                Teacher teacher = teacherService.GetTeacherByID(teacherID);
                dayOfWeek = (DayOfWeek)int.Parse(values[2]);
                startTime = reader.ReadLine();
                endTime = reader.ReadLine();
                regularList.Add(new RegularLesson(subject, teacher, startTime, endTime, dayOfWeek));
            }

            reader = new StreamReader(GetPath(OneTimeLessonFileName));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                subjectID = int.Parse(values[0]);
                Subject subject = subjectService.GetById(subjectID);
                teacherID = int.Parse(values[1]);
                Teacher teacher = teacherService.GetTeacherByID(teacherID);
                startTime = reader.ReadLine();
                string[] startTimeComponents = startTime.Split(' ');
                endTime = reader.ReadLine();
                string[] endTimeComponents = endTime.Split(' ');
                DateTime date = new DateTime(int.Parse(startTimeComponents[0]), int.Parse(startTimeComponents[1]),
                    int.Parse(startTimeComponents[2]), 0, 0, 0);
                oneTimeList.Add(new OneTimeLesson(subject, teacher, $"{startTimeComponents[3]}:{startTimeComponents[4]}",
                    $"{endTimeComponents[3]}:{endTimeComponents[4]}", date));
            }
            //MessageBox.Show($"{regularList[0].GetDayOfWeek()} {regularList[1].GetDayOfWeek()}");
            return lessons.Concat(regularList).Concat(oneTimeList).ToList();
        }

        public List<Subject> ReadSubjects()
        {
            string path = GetPath(SubjectFileName);
            List<Subject> subjectList = new List<Subject>();

            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                subjectList = System.Text.Json.JsonSerializer.Deserialize<List<Subject>>(jsonString);
            }
            else
            {
                MessageBox.Show("Unable to find a file with subject data");
            }

            return subjectList;
        }

        public List<Teacher> ReadTeachers()
        {
            string pathPrivateTeacher = GetPath(PrivateTeacherFileName);
            List<PrivateTeacher> privateTeachersList = new List<PrivateTeacher>();
            string pathSchoolTeacher = GetPath(SchoolTeacherFileName);
            List<SchoolTeacher> schoolTeachersList = new List<SchoolTeacher>();
            List<Teacher> allTeachers = new List<Teacher>();

            if (File.Exists(pathPrivateTeacher))
            {
                string inputText = File.ReadAllText(pathPrivateTeacher);
                privateTeachersList = JsonConvert.DeserializeObject<List<PrivateTeacher>>(inputText);
            }
            else
            {
                MessageBox.Show("Unable to find a file with data");
            }

            if (File.Exists(pathSchoolTeacher))
            {
                string inputText = File.ReadAllText(pathSchoolTeacher);
                schoolTeachersList = JsonConvert.DeserializeObject<List<SchoolTeacher>>(inputText);
            }
            else
            {
                MessageBox.Show("Unable to find a file with data");
            }
            allTeachers = allTeachers.Concat(schoolTeachersList).Concat(privateTeachersList).ToList();
            return allTeachers;
        }

        /*public void WriteLessons()
        {
            //var jsonContent = JsonConvert.SerializeObject(lessonService.GetOneTime());
            //string path = GetPath(OneTimeLessonFileName);
            //File.WriteAllText(path, jsonContent);

            var options = new JsonSerializerOptions { IncludeFields = true };
            try
            {
                string path = GetPath(OneTimeLessonFileName);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(lessonService.GetOneTime(), options);
                File.WriteAllText(path, jsonString);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            //jsonContent = JsonConvert.SerializeObject(lessonService.GetRegular());
            //path = GetPath(RegularLessonFileName);
            //File.WriteAllText(path, jsonContent);

            try
            {
                string path = GetPath(RegularLessonFileName);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(lessonService.GetRegular(), options);
                File.WriteAllText(path, jsonString);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }*/

        public void WriteLessons()
        {
            if(lessonService.GetRegular().Count == 0)
            {
                File.WriteAllText(GetPath(RegularLessonFileName), "");
            }
            if (lessonService.GetOneTime().Count == 0)
            {
                File.WriteAllText(GetPath(OneTimeLessonFileName), "");
            }

            string path = GetPath(OneTimeLessonFileName);
            StringBuilder lessons = new StringBuilder();
            foreach (var item in lessonService.GetOneTime())
            {
                lessons.AppendLine($"{item.SubjectID};{item.TeacherID}");
                lessons.AppendLine(item.StartTime);
                lessons.AppendLine(item.EndTime);
            }
            File.WriteAllText(path, lessons.ToString());

            path = GetPath(RegularLessonFileName);
            lessons = new StringBuilder();
            foreach (var item in lessonService.GetRegular())
            {
                lessons.AppendLine($"{item.SubjectID};{item.TeacherID};{(int)item.GetDayOfWeek()}");
                lessons.AppendLine(item.StartTime);
                lessons.AppendLine(item.EndTime);
            }
            File.WriteAllText(path, lessons.ToString());
        }

        public void WriteSubjects()
        {
            string path = GetPath(SubjectFileName);
            string jsonString = System.Text.Json.JsonSerializer.Serialize(subjectService.Get());
            File.WriteAllText(path, jsonString);
        }

        public void WriteTeachers()
        {
            var jsonContent = JsonConvert.SerializeObject(teacherService.GetSchoolTeachers());
            string path = GetPath(SchoolTeacherFileName);
            File.WriteAllText(path, jsonContent);

            jsonContent = JsonConvert.SerializeObject(teacherService.GetPrivateTeachers());
            path = GetPath(PrivateTeacherFileName);
            File.WriteAllText(path, jsonContent);
        }

        public void Save()
        {
            CheckAndCreateDirectory();
;
            WriteTeachers();
            WriteSubjects();
            WriteLessons();
        }

        public void Import()
        {
            DataBase dataBase = new DataBase();
            dataBase.UpdateDatabase();
        }

        private void CheckAndCreateDirectory()
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"DataFolder\");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string GetPath(string fileName)
        {
            return System.IO.Path.Combine(Environment.CurrentDirectory, @"DataFolder\", fileName);
        }
    }
}
