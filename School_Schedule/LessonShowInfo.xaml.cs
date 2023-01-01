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
            SubjectInfo.Text = $"{Lesson.GetSubject().Name}";
            TeacherInfo.Text = $"{Lesson.GetTeacher().Name} {Lesson.GetTeacher().Surname} {Lesson.GetTeacher().Patronymic}";

            TimeInfo.Text = GetFullTimeInfo();
            TimeInfo.Text += $"{Lesson.GetStartTime().Hour}:{Lesson.GetStartTime().Minute}-" +
                    $"{Lesson.GetEndTime().Hour}:{Lesson.GetEndTime().Minute}";
            //про вчителя інформація повинна показуватися відповідно до того, приватний він чи шкільний
            FullTeacherInfo.Content = $"Phone: {Lesson.GetTeacher().PhoneNumber}\n{GetFullTeacherInfo()}\n" +
                $"{Lesson.GetTeacher().AdditionalInfo}";
            LessonInfo.Content = $"Type: {Lesson.GetSubject().Type} \nLink: {Lesson.GetSubject().Link}\n" +
                $"Homework: {Lesson.GetSubject().Homework}";
        }

        private string GetFullTimeInfo()
        {
            try
            {
                RegularLesson rLesson = (RegularLesson)Lesson;
                if((int)rLesson.GetDayOfWeek() == 7)
                {
                    return "Sunday ";
                }
                return $"{rLesson.GetDayOfWeek()} ";
            } catch { }
            try
            {
                OneTimeLesson oneLesson = (OneTimeLesson)Lesson;
                return $"{oneLesson.GetStartTime().Day}.{oneLesson.GetStartTime().Month}.{oneLesson.GetStartTime().Year} ";
            } catch {}
            return "";
        }

        private string GetFullTeacherInfo()
        {
            Teacher teacher = Lesson.GetTeacher();
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
