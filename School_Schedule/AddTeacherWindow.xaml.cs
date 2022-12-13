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
    /// Interaction logic for AddTeacherWindow.xaml
    /// </summary>
    public partial class AddTeacherWindow : Window
    {
        public AddTeacherWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if ((NameField.Text != "") && (SurnameField.Text != "" ||
                PatronymicField.Text != "") &&
                (SchoolTeacherButton.IsChecked == true || 
                PrivateTeacherButton.IsChecked == true))
            {
                //можна створювати учителя лише якщо є прізвище та ім'я,
                //або ім'я та по-батькові
                //і обов'язково повинна бути натиснута якась радіо-кнопка
                //створюється об'єкт учителя

                if(SchoolTeacherButton.IsChecked == true)
                {
                    new SchoolTeacher(NameField.Text, 
                        SurnameField.Text, PatronymicField.Text, PhoneNumberField.Text,
                        OfficeField.Text, AdditionalInfoField.Text);
                    MessageBox.Show("Added succesfully");
                    Close();
                }
                else
                {
                    try
                    {
                        new PrivateTeacher(NameField.Text,
                        SurnameField.Text, PatronymicField.Text, PhoneNumberField.Text,
                        AddressField.Text, int.Parse(PriceField.Text), AdditionalInfoField.Text);
                        MessageBox.Show("Added succesfully");
                        Close();
                    }
                    catch
                    {
                        MessageBox.Show("Price must be a number");
                    }
                }
            }
            else
            {
                MessageBox.Show("Some neccessary fiels are empty");
            }
        }

        private void PrivateTeacherButton_Checked(object sender, RoutedEventArgs e)
        {
            PriceField.IsEnabled = true;
            AddressField.IsEnabled = true;
            OfficeField.IsEnabled = false;
        }

        private void SchoolTeacherButton_Checked(object sender, RoutedEventArgs e)
        {
            OfficeField.IsEnabled = true;
            PriceField.IsEnabled = false;
            AddressField.IsEnabled = false;
        }
    }
}
