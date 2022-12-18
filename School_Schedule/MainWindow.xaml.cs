using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using School_Schedule.Logic.SubjectFolder;
using School_Schedule.Logic.TeacherFolder;
using School_Schedule.Logic.LessonFolder;
using School_Schedule.DataBase.Services;
using School_Schedule.DataBase.FileReadWrite;

namespace School_Schedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LessonBlocksService LessonBlocksService = new LessonBlocksService();
        private List<Canvas> Canvases;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddSubjectWindow window = new AddSubjectWindow();
            window.ShowDialog();
            if(window.NewLesson != null)
            {
                BaseLesson newLesson = window.NewLesson;
                CreateLesson(newLesson);
                RefreshButton_Click();
            }
            //отримую з методів іншого вікна значення нового предмету
            //закриваю процес для вікна
            //створюю новий урок у розкладі
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new Subject("Math", "nothing", "", "");
            new Subject("Physic", "nothing", "", "");
            new Subject("History", "nothing", "", "");
            new Subject("Language", "nothing", "", "");

            CreateTimeLine();
            CreateCurrentTimeLine();
            RefreshButton_Click();
            Canvases = new List<Canvas> { Monday, Tuesday, Wednesday, Thursday, Friday,
            Saturday, Sunday };
        }

        private void CreateLesson(BaseLesson lesson)
        {
            int top = lesson.Start.Hour *60 + lesson.Start.Minute;
            int bottom = lesson.End.Hour*60 + lesson.End.Minute;
            int height = bottom - top;

            string text;
            if (height >= 60)
            {
                text = $"{lesson.Subject.Name}\n{lesson.Teacher.Name}" +
                    $"\n{lesson.Start.Hour}:{lesson.Start.Minute}-" +
                    $"{lesson.End.Hour}:{lesson.End.Minute}";
            }
            else if (height > 40)
            {
                text = $"{lesson.Subject.Name}\n{lesson.Start.Hour}:{lesson.Start.Minute}-" +
                    $"{lesson.End.Hour}:{lesson.End.Minute}";
            }
            else
            {
                text = $"{lesson.Subject.Name}";
            }

            TextBlock lessonButton = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Text = text,
                FontSize = 14,
                Width = Monday.ActualWidth,
                Height = height,
                Background = new SolidColorBrush(Color.FromRgb(231, 113, 125)),
            };
            Canvas.SetTop(lessonButton, top);
            switch (lesson.GetDayOfWeek())
            {
                case DayOfWeek.Monday: Monday.Children.Add(lessonButton); break;
                case DayOfWeek.Tuesday: Tuesday.Children.Add(lessonButton); break;
                case DayOfWeek.Wednesday: Wednesday.Children.Add(lessonButton); break;
                case DayOfWeek.Thursday: Thursday.Children.Add(lessonButton); break;
                case DayOfWeek.Friday: Friday.Children.Add(lessonButton); break;
                case DayOfWeek.Saturday: Saturday.Children.Add(lessonButton); break;
                case DayOfWeek.Sunday: Sunday.Children.Add(lessonButton); break;
            }
            LessonBlocksService.Add(lessonButton, lesson);
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

        private void CreateCurrentTimeLine()
        {
            Rectangle currentTimeLine = new Rectangle
            {
                Height = 2,
                Width = ActualWidth,
                StrokeThickness = 2,
                Stroke = new SolidColorBrush(Color.FromArgb(40, 126, 104, 90)),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
            };
            Canvas.SetTop(currentTimeLine, DateTime.Now.Hour * 60 + DateTime.Now.Minute);
            TimeLineCanvas.Children.Add(currentTimeLine);

            TextBlock currentTime = new TextBlock
            {
                Text = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}",
                FontSize = 10,
                Background = new SolidColorBrush(Color.FromRgb(173, 210, 117)),
        };
            Canvas.SetTop(currentTime, DateTime.Now.Hour * 60 + DateTime.Now.Minute);
            TimeLineCanvas.Children.Add(currentTime);
        }

        private void SetCurrentLesson()
        {
            try
            {
                TextBlock currentLesson = LessonBlocksService.FindCurrent();
                currentLesson.Background = new SolidColorBrush(Color.FromRgb(173, 210, 117));
            }
            catch (Exception) { }
        }

        private void SetNotCurrentLessons()
        {
            LessonBlocksService lessonBlocksService = new LessonBlocksService();
            List<TextBlock> notCurrentLessons = lessonBlocksService.GetLessonsThatIsNotCurrentNow();
            foreach(var block in notCurrentLessons)
            {
                block.Background = new SolidColorBrush(Color.FromRgb(231, 113, 125));
            }
        }

        private void RemoveDeletedLessons()
        {
            DeleteService deleteQueueService = new DeleteService();
            List<TextBlock> toDelete = deleteQueueService.GetList();
            foreach(TextBlock item in toDelete)
            {
                Canvases.ForEach(x => x.Children.Remove(item));
            }
            deleteQueueService.Clean();
        }

        private void RefreshButton_Click(object sender=null, RoutedEventArgs e=null)
        {
            SetCurrentLesson();
            //і ще має бути функція зміни кольору з червоного на зелений, якщо урок уже триває
            LessonBlocksService lessonBlocksService = new LessonBlocksService();
            lessonBlocksService.DeleteOneTimeLessonsThatAreGone();
            RemoveDeletedLessons();
            SetNotCurrentLessons();

            ReadWriteManager readWriteManager = new ReadWriteManager();
            readWriteManager.Import();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            object originalSource = e.OriginalSource;
            if (originalSource is TextBlock block)
            {
                BaseLesson lesson = LessonBlocksService.GetValue(block);
                if(LessonBlocksService.ContainsKey(block) && lesson != null)
                {
                    lesson.ShowInfo();
                    RefreshButton_Click();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ReadWriteManager readWriteManager = new ReadWriteManager();
            readWriteManager.Save();
            MessageBox.Show("Hello, " + Environment.UserName);
            MessageBox.Show("In Developing");
        }
    }
}
