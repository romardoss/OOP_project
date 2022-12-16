using System.Windows;
using School_Schedule.Logic.TeacherFolder;
using School_Schedule.Logic.LessonFolder;
using School_Schedule.DataBase.Services;

namespace School_Schedule
{
    /// <summary>
    /// Interaction logic for LessonShowInfo.xaml
    /// </summary>
    public partial class LessonShowInfo : Window
    {
        private BaseLesson Lesson { get; set; }

        public LessonShowInfo(BaseLesson lesson)
        {
            InitializeComponent();
            Lesson = lesson;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateLessonInfo();
        }

        private void GenerateLessonInfo()
        {
            SubjectInfo.Text = $"{Lesson.Subject.Name}";
            TeacherInfo.Text = $"{Lesson.Teacher.Name} {Lesson.Teacher.Surname} {Lesson.Teacher.Patronymic}";

            TimeInfo.Text = GetFullTimeInfo();
            TimeInfo.Text += $"{Lesson.Start.Hour}:{Lesson.Start.Minute}-" +
                    $"{Lesson.End.Hour}:{Lesson.End.Minute}";
            //про вчителя інформація повинна показуватися відповідно до того, приватний він чи шкільний
            FullTeacherInfo.Content = $"Phone: {Lesson.Teacher.PhoneNumber}\n{GetFullTeacherInfo()}\n" +
                $"{Lesson.Teacher.AdditionalInfo}";
            LessonInfo.Content = $"Type: {Lesson.Subject.Type} \nLink: {Lesson.Subject.Link}\n" +
                $"Homework: {Lesson.Subject.Homework}";
        }

        private string GetFullTimeInfo()
        {
            try
            {
                RegularLesson rLesson = (RegularLesson)Lesson;
                return $"{rLesson.DayOfWeek} ";
            } catch { }
            try
            {
                OneTimeLesson oneLesson = (OneTimeLesson)Lesson;
                return $"{oneLesson.Start.Day}.{oneLesson.Start.Month}.{oneLesson.Start.Year} ";
            } catch {}
            return "";
        }

        private string GetFullTeacherInfo()
        {
            Teacher teacher = Lesson.Teacher;
            try
            {
                SchoolTeacher sTeacher = (SchoolTeacher) teacher;
                return $"Office: {sTeacher.OfficeNumber}";
            } catch { }
            try
            {
                PrivateTeacher pTeacher = (PrivateTeacher) teacher;
                return $"Price of lesson: {pTeacher.PriceOfLesson} \nAddress: {pTeacher.Address}";
            } catch { }
            return "";
        }

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DeleteLessonButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteService deleteService = new DeleteService();
            deleteService.MoveToTrash(Lesson);
            MessageBox.Show("Deleted Successfully");
            Close();
        }

    }
}
