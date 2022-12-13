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
    /// Interaction logic for CreateSubjectWindow.xaml
    /// </summary>
    public partial class CreateSubjectWindow : Window
    {
        public CreateSubjectWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameField.Text != "")
            {
                new Subject(NameField.Text, TypeField.Text,
                    HomeworkField.Text, LinkField.Text);
                MessageBox.Show("Created Successfully");
                Close();
            }
            else
            {
                MessageBox.Show("Name field is empty");
            }
        }
    }
}
