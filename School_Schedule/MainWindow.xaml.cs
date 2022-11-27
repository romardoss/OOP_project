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
using System.Windows.Navigation;
using System.Windows.Shapes;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;
using School_Schedule.Logic.LessonFolder;

namespace School_Schedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Content = "wow";
            //MessageBox.Show("You`re so well");
            AddSubjectWindow window = new AddSubjectWindow();
            window.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Subject math = new Subject("Math", "Lidiia", "nothing");
            new Subject("Physic", "Oleg", "nothing");
            new Subject("History", "Olesya", "nothing");
            new Subject("Language", "Liana", "nothing");
            new SchoolTeacher("Oleg", "Slyva", "Oleksandrovich", "000", "Math", "12");
            new SchoolTeacher("Andrew", "Slyva", "Oleksandrovich", "000", "Math", "12");
            //MessageBox.Show(DateTime.Today.DayOfWeek.ToString());
            DayOfWeek dayOfWeek = DayOfWeek.Monday;
            DateTime start = new DateTime(DateTime.Today.Year, 
                DateTime.Today.Month, DateTime.Today.Day, 16, 30, 0);
            DateTime end = new DateTime(DateTime.Today.Year,
                DateTime.Today.Month, DateTime.Today.Day, 19, 30, 0);
            //Lesson l = new Lesson(math, dayOfWeek, start, end);
            //MessageBox.Show(l.IsNow().ToString());
            listTest.ItemsSource = new List<string> {"Урок 1", "Урок 2",
            "Урок 3", "Урок 4", "Урок 5", "Урок 6", "Урок 7", "Урок 8",
            "Урок 9", "Урок 10", "Урок 11", "Урок 12", "Урок 13", "Урок 14",
            "Урок 15", "Урок 16", "Урок 17", "Урок 18", "Урок 19", "Урок 20", };
        }
    }
}
