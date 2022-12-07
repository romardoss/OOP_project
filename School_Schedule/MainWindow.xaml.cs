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
            Lesson newLesson = window.NewLesson;
            CreateLesson(newLesson);
            //отримую з методів іншого вікна значення нового предмету
            //закриваю процес для вікна
            //створюю новий урок у розкладі
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


            CreateTimeLine();
        }

        private void CreateLesson(Lesson lesson)
        {
            int top = lesson.Start.Hour *60 + lesson.Start.Minute;
            int bottom = lesson.End.Hour*60 + lesson.End.Minute;
            int height = bottom - top;
            //MessageBox.Show($"{top} {bottom} {height}");

            Button lessonButton = new Button
            {
                Width = Monday.ActualWidth,
                Height = height,
                Content = $"{lesson.Subject.Name}\n{lesson.Subject.Teacher}" +
                $"\n{lesson.Start.Hour}:{lesson.Start.Minute}-" +
                $"{lesson.End.Hour}:{lesson.End.Minute}",

            };
            Canvas.SetTop(lessonButton, top);
            switch (lesson.DayOfWeek)
            {
                case DayOfWeek.Monday: Monday.Children.Add(lessonButton); break;
                case DayOfWeek.Tuesday: Tuesday.Children.Add(lessonButton); break;
                case DayOfWeek.Wednesday: Wednesday.Children.Add(lessonButton); break;
                case DayOfWeek.Thursday: Thursday.Children.Add(lessonButton); break;
                case DayOfWeek.Friday: Friday.Children.Add(lessonButton); break;
                case DayOfWeek.Saturday: Saturday.Children.Add(lessonButton); break;
                case DayOfWeek.Sunday: Sunday.Children.Add(lessonButton); break;
            }
        }

        private void CreateTimeLine()
        {
            for (int i = 0; i < 24; i++)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = $"{i}:00",
                    FontSize = 16,
                    TextAlignment = TextAlignment.Center,
                };
                Canvas.SetTop(textBlock, i * 60);
                TimeLineCanvas.Children.Add(textBlock);
            }
        }

    }
}
