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
        }
    }
}
