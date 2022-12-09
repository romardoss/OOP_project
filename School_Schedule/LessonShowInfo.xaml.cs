using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;
using School_Schedule.Logic.LessonFolder;

namespace School_Schedule
{
    /// <summary>
    /// Interaction logic for LessonShowInfo.xaml
    /// </summary>
    public partial class LessonShowInfo : Window
    {
        private Lesson Lesson { get; set; }

        public LessonShowInfo(Lesson lesson)
        {
            InitializeComponent();
            Lesson = lesson;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SubjectInfo.Text = $"{Lesson.Subject.Name}";
            TeacherInfo.Text = $"{Lesson.Teacher.Name} {Lesson.Teacher.Surname} {Lesson.Teacher.Patronymic}";
            TimeInfo.Text = $"{Lesson.DayOfWeek} {Lesson.Start.Hour}:{Lesson.Start.Minute}-" +
                    $"{Lesson.End.Hour}:{Lesson.End.Minute}";
            FullTeacherInfo.Content = $"Phone: {Lesson.Teacher.PhoneNumber}\nfsdfs\nskf";
            HomeworkInfo.Content = $"{Lesson.Subject.Homework}";
        }

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
