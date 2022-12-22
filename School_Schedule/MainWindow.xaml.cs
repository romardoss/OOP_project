﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
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
                CreateLessonBlock(newLesson);
                RefreshButton_Click();
            }
            //отримую з методів іншого вікна значення нового предмету
            //закриваю процес для вікна
            //створюю новий урок у розкладі
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateTimeLine();
            CreateCurrentTimeLine();
            RefreshButton_Click();
            Canvases = new List<Canvas> { Monday, Tuesday, Wednesday, Thursday, Friday,
            Saturday, Sunday };

            ReadWriteManager readWriteManager = new ReadWriteManager();
            try
            {
                readWriteManager.Import();
            }
            catch(Exception k)
            {
                MessageBox.Show(k.Message);
            }
            UpdateLessonBlocksOnCanvas();
        }

        private TextBlock CreateLessonBlock(BaseLesson lesson)
        {
            int top = lesson.GetStartTime().Hour *60 + lesson.GetStartTime().Minute;
            int bottom = lesson.GetEndTime().Hour*60 + lesson.GetEndTime().Minute;
            int height = bottom - top;

            string text;
            if (height >= 60)
            {
                text = $"{lesson.GetSubject().Name}\n{lesson.GetTeacher().Name}" +
                    $"\n{lesson.GetStartTime().Hour}:{lesson.GetStartTime().Minute}-" +
                    $"{lesson.GetEndTime().Hour}:{lesson.GetEndTime().Minute}";
            }
            else if (height > 40)
            {
                text = $"{lesson.GetSubject().Name}\n{lesson.GetStartTime().Hour}:{lesson.GetStartTime().Minute}-" +
                    $"{lesson.GetEndTime().Hour}:{lesson.GetEndTime().Minute}";
            }
            else
            {
                text = $"{lesson.GetSubject().Name}";
            }

            TextBlock block = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Text = text,
                FontSize = 14,
                Width = Monday.ActualWidth,
                Height = height,
                Background = new SolidColorBrush(Color.FromRgb(231, 113, 125)),
            };
            Canvas.SetTop(block, top);
            LessonBlocksService.Add(block, lesson);
            return block;
        }

        private void AddLessonBlockToTheCanvas(BaseLesson lesson, TextBlock block)
        {
            switch ((int)lesson.GetDayOfWeek())
            {
                case 1: Monday.Children.Add(block); break;
                case 2: Tuesday.Children.Add(block); break;
                case 3: Wednesday.Children.Add(block); break;
                case 4: Thursday.Children.Add(block); break;
                case 5: Friday.Children.Add(block); break;
                case 6: Saturday.Children.Add(block); break;
                case 7: Sunday.Children.Add(block); break;
            }
        }

        private void UpdateLessonBlocksOnCanvas()
        {
            LessonService lessonService = new LessonService();
            foreach (var lesson in lessonService.Get())
            {
                TextBlock block = CreateLessonBlock(lesson);
                AddLessonBlockToTheCanvas(lesson, block);
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
            List<TextBlock> notCurrentLessons = lessonBlocksService.GetLessonsThatAreNotCurrentNow();
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
            UpdateLessonBlocksOnCanvas();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            object originalSource = e.OriginalSource;
            if (originalSource is TextBlock block)
            {
                BaseLesson lesson = LessonBlocksService.GetValue(block);
                if (LessonBlocksService.ContainsKey(block) && lesson != null)
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
            //MessageBox.Show("Hello, " + Environment.UserName);
            MessageBox.Show("In Developing");
        }
    }
}
