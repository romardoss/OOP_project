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
using School_Schedule.DataBase.Services;

namespace School_Schedule
{
    /// <summary>
    /// Interaction logic for AddSubjectWindow.xaml
    /// </summary>

    public partial class AddSubjectWindow : Window
    {
        public Lesson NewLesson;
        private readonly SubjectService SubjectService = new SubjectService();
        private readonly LessonService LessonService = new LessonService();
        private readonly TeacherService TeacherService = new TeacherService();

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
            UpdateLists();
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
            

            if (StartTime.Text == "" || EndTime.Text == "" || 
                ChoseSubject.Text == "" || ChoseTeacher.Text == ""
                || ChoseDayOfWeek.Text == "")
            {
                MessageBox.Show("Some fields are empty");
            }
            else
            {
                //Subject subject = Subject.AllSubjects.First(x => x.Name == ChoseSubject.Text);
                //Teacher teacher = Teacher.AllTeachers.First(x => x.Name == ChoseTeacher.Text);
                Subject subject = SubjectService.GetByName(ChoseSubject.Text);
                Teacher teacher = TeacherService.GetByName(ChoseTeacher.Text);

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
                    Close();
                }
                else
                {
                    //тут повинна бути логіка для разового уроку
                }
            }
            
        }

        private void AddNewTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherWindow window = new AddTeacherWindow();
            window.ShowDialog();
            UpdateLists();
        }

        private void AddNewSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            CreateSubjectWindow window = new CreateSubjectWindow();
            window.ShowDialog();
            UpdateLists();
        }

        private void UpdateLists()
        {
            //ChoseSubject.ItemsSource = Subject.AllSubjects.Select(x => x.Name);
            //ChoseTeacher.ItemsSource = Teacher.AllTeachers.Select(x => x.Name);
            ChoseSubject.ItemsSource = SubjectService.GetNames();
            ChoseTeacher.ItemsSource = TeacherService.GetNames();
        }
    }
}
