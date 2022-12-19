using Newtonsoft.Json;
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
        private readonly string RegularLessonFileName = "RegularLessonData.json";
        private readonly string OneTimeLessonFileName = "OneTimeLessonData.json";
        private readonly string LessonBlockFileName = "LessonBlockData.json";

        public Dictionary<TextBlock, BaseLesson> ReadLessonBlocks()
        {
            string path = GetPath(LessonBlockFileName);
            Dictionary<TextBlock, BaseLesson> blockList = new Dictionary<TextBlock, BaseLesson>();

            if (File.Exists(path))
            {
                string inputText = File.ReadAllText(path);
                blockList = JsonConvert.DeserializeObject<Dictionary<TextBlock, BaseLesson>>(inputText);
            }
            else
            {
                MessageBox.Show("Unable to find a file with data");
            }

            return blockList;
        }

        public List<BaseLesson> ReadLessons()
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
        }

        public List<Subject> ReadSubjects()
        {
            string path = GetPath(SubjectFileName);
            List<Subject> subjectList = new List<Subject>();

            if (File.Exists(path))
            {
                string inputText = File.ReadAllText(path);
                subjectList = JsonConvert.DeserializeObject<List<Subject>>(inputText);
            }
            else
            {
                MessageBox.Show("Unable to find a file with data");
            }

            return subjectList;
        }

        public List<Teacher> ReadTeachers()
        {
            string pathPrivateTeacher = GetPath(PrivateTeacherFileName);
            List<PrivateTeacher> privateTeachersList = new List<PrivateTeacher>();
            string pathSchoolTeacher = GetPath(PrivateTeacherFileName);
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
            //MessageBox.Show(String.Join(" ", allTeachers));
            return allTeachers;
        }

        public void WriteLessonBlocks()
        {
            var jsonContent = JsonConvert.SerializeObject(lessonBlocksService.Get());
            string path = GetPath(LessonBlockFileName);
            File.WriteAllText(path, jsonContent);
        }

        public void WriteLessons()
        {
            var jsonContent = JsonConvert.SerializeObject(lessonService.GetOneTime());
            string path = GetPath(OneTimeLessonFileName);
            File.WriteAllText(path, jsonContent);

            jsonContent = JsonConvert.SerializeObject(lessonService.GetRegular());
            path = GetPath(RegularLessonFileName);
            File.WriteAllText(path, jsonContent);
        }

        

        public void WriteSubjects()
        {
            var jsonContent = JsonConvert.SerializeObject(subjectService.Get());
            string path = GetPath(SubjectFileName);
            File.WriteAllText(path, jsonContent);
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

            //WriteLessonBlocks();
            WriteSubjects();
            WriteLessons();
            WriteTeachers();
        }

        public void Import()
        {
            DataBase dataBase = new DataBase();
            dataBase.UpdateDatabase();
        }

        private void CheckAndCreateDirectory()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"DataFolder\");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string GetPath(string fileName)
        {
            return Path.Combine(Environment.CurrentDirectory, @"DataFolder\", fileName);
        }
    }
}
