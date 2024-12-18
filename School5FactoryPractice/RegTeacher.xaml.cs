using School5FactoryPractice.Data;
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

namespace School5FactoryPractice
{
    /// <summary>
    /// Interaction logic for RegTeacher.xaml
    /// </summary>
    public partial class RegTeacher : Page
    {
        public RegTeacher()
        {
            InitializeComponent();

            var _firstBackgroundPath = "src\\background.mp4";
            var _secBackgroundPath = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _firstBackgroundPath));

            ME_Background.Source = _secBackgroundPath;
            ME_Background.Play();

            var _firstImageTeacherPath = "src\\teacher.png";
            var _secImageTeacherPath = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _firstBackgroundPath));

            var _firstImageStudentPath = "src\\student.png";
            var _secImageStudentPath = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _firstBackgroundPath));

            Window parentWindow = Window.GetWindow(this);

            parentWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void BN_Reg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TB_Name.Text) || string.IsNullOrEmpty(TB_Email.Text) || string.IsNullOrEmpty(TB_PhoneNumber.Text) || string.IsNullOrEmpty(TB_Login.Text) || string.IsNullOrEmpty(TB_Pass.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        User _newUser = new User
                        {
                            Name = TB_Name.Text,
                            Email = TB_Email.Text,
                            PhoneNumber = Convert.ToInt64(TB_PhoneNumber.Text),
                            Role = "Учитель",
                            Login = TB_Login.Text,
                            Password = TB_Pass.Text
                        };

                        MessageBox.Show("Вы зарегистрировались!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                        db.Add(_newUser);
                        db.SaveChanges();
                    }
                }

                catch (Exception ex) 
                {
                    MessageBox.Show("Где-то возникла ошибка! Попробуйте заполнить номер телефона в правильном формате - (80000000000)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ME_Background_MediaEnded(object sender, RoutedEventArgs e)
        {
            var _firstBackgroundPath = "src\\background.mp4";
            var _secBackgroundPath = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _firstBackgroundPath));

            ME_Background.Source = _secBackgroundPath;
            ME_Background.Play();
        }

        private void BN_Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LL_ToAuth_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Auth());

        }

        private void TB_Pass_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Pass.Text = "";
        }

        private void TB_Name_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Name.Text = "";
        }

        private void TB_FIO_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_FIO.Text = "";
        }

        private void TB_Email_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Email.Text = "";
        }

        private void TB_PhoneNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_PhoneNumber.Text = "";
        }

        private void TB_Login_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Login.Text = "";
        }
    }
}
