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
    /// Interaction logic for AddSubjectWindow.xaml
    /// </summary>

    public partial class AddSubjectWindow : Window
    {

        public Lesson NewLesson { get; set; }

        public AddSubjectWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            DateOfLesson.IsEnabled = true;
            ChoseDayOfWeek.IsEnabled = false;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            DateOfLesson.IsEnabled = false;
            ChoseDayOfWeek.IsEnabled = true;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChoseSubject.ItemsSource = Subject.AllNames;
            ChoseTeacher.ItemsSource = Teacher.AllNames;
            ChoseDayOfWeek.ItemsSource = new List<string>{"Monday", 
                "Tuesday", "Wednesday", "Thursday", "Friday", 
                "Saturday", "Sunday"};
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Subject subject = Subject.AllSubjects.First(x => x.Name == ChoseSubject.Text);
            Teacher teacher = Teacher.AllTeachers.First(x => x.Name == ChoseTeacher.Text);

            if (StartTime.Text == "" || EndTime.Text == "" || 
                ChoseSubject.Text == "" || ChoseTeacher.Text == ""
                || ChoseDayOfWeek.Text == "")
            {
                MessageBox.Show("Some fields are empty");
            }

            if (CheckBox.IsChecked == false)
            {
                DayOfWeek dayOfWeek;
                switch (ChoseDayOfWeek.Text)
                {
                    case "Monday": dayOfWeek = DayOfWeek.Monday; break;
                    case "Tuesday": dayOfWeek = DayOfWeek.Tuesday; break;
                    case "Wednesday": dayOfWeek = DayOfWeek.Wednesday; break;
                    case "Thursday": dayOfWeek = DayOfWeek.Thursday; break;
                    case "Friday": dayOfWeek = DayOfWeek.Friday; break;
                    case "Saturday": dayOfWeek = DayOfWeek.Saturday; break;
                    case "Sunday": dayOfWeek = DayOfWeek.Sunday; break;
                    default: throw new Exception("The wrong day of week");
                }

                NewLesson = new Lesson(subject, teacher, StartTime.Text, EndTime.Text, dayOfWeek);
                MessageBox.Show("added successfuly");

            }
            else
            {

            }
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherWindow window = new AddTeacherWindow();
            window.ShowDialog();
        }
    }
}
