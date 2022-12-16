using System.Windows;
using School_Schedule.Logic.SubjectFolder;

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
