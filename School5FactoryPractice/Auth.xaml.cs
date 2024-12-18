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
using System.IO;
using School5FactoryPractice.Data;
using System.Data.Common;

namespace School5FactoryPractice
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();

            var _firstBackgroundPath = "src\\background.mp4";
            var _secBackgroundPath = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _firstBackgroundPath));

            ME_Background.Source = _secBackgroundPath;
            ME_Background.Play();

            Window parentWindow = Window.GetWindow(this);

            parentWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        List<string> _currentUsersData;

        private void CB_HideOrShow_Checked(object sender, RoutedEventArgs e)
        {
            PB_Pass.Password = TB_Pass.Text;
            PB_Pass.Visibility = Visibility.Visible;
            TB_Pass.Visibility = Visibility.Collapsed;
        }

        private void CB_HideOrShow_Unchecked(object sender, RoutedEventArgs e)
        {
            TB_Pass.Text = PB_Pass.Password;
            TB_Pass.Visibility = Visibility.Visible;
            PB_Pass.Visibility = Visibility.Collapsed;
        }

        private void ME_Background_MediaEnded(object sender, RoutedEventArgs e)
        {
            var _firstBackgroundPath = "src\\background.mp4";
            var _secBackgroundPath = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _firstBackgroundPath));

            ME_Background.Source = _secBackgroundPath;
            ME_Background.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Reg());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TB_Pass_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Pass.Text = "";
        }

        private void TB_Login_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Login.Text = "";

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TB_Login.Text) && string.IsNullOrEmpty(TB_Pass.Text))
            {
            }
            else
            {
                try
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var _currentUser = db.Users.FirstOrDefault(u => u.Login == TB_Login.Text && u.Password == TB_Pass.Text);

                        //var _usersList = db.Users.ToList();

                        //foreach (var _user in _usersList)
                        //{
                        //    _currentUsersData.Add($"{_user.UserId} {_user.Name} {_user.Role}");
                        //}



                        if ( _currentUser != null)
                        {
                            if (_currentUser.Role == "Учитель")
                            {
                                NavigationService.Navigate(new MainTeacherPage());

                                MessageBox.Show("Вы вошли!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if(_currentUser.Role == "Ученик")
                            {
                                NavigationService.Navigate(new MainStudentPage());

                                MessageBox.Show("Вы вошли!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            }        
                            else if(_currentUser.Role == "Администратор")
                            {
                                NavigationService.Navigate(new MainAdminPage());

                                MessageBox.Show("Вы вошли!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch(Exception ex) { }
            }

        }
    }
}
