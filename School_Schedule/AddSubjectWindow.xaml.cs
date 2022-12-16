using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
        public BaseLesson NewLesson;
        private readonly SubjectService SubjectService = new SubjectService();
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
                ChoseSubject.Text == "" || ChoseTeacher.Text == "")
            {
                MessageBox.Show("Some fields are empty");
            }
            else
            {
                Subject subject = SubjectService.GetByName(ChoseSubject.Text);
                Teacher teacher = TeacherService.GetByName(ChoseTeacher.Text);

                if (CheckBox.IsChecked == false && ChoseDayOfWeek.Text != "")
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

                    NewLesson = new RegularLesson(subject, teacher, StartTime.Text, EndTime.Text, 
                        dayOfWeek);
                    MessageBox.Show("added successfuly");
                    Close();
                }
                else if (CheckBox.IsChecked == true && DateOfLesson.SelectedDate != null)
                {
                    NewLesson = new OneTimeLesson(subject, teacher, StartTime.Text, 
                        EndTime.Text, DateOfLesson.SelectedDate.Value);
                    MessageBox.Show("In developing...");
                    Close();
                }
                else
                {
                    MessageBox.Show("Some fields are empty");
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
            ChoseSubject.ItemsSource = SubjectService.GetNames();
            ChoseTeacher.ItemsSource = TeacherService.GetNames();
        }
    }
}
