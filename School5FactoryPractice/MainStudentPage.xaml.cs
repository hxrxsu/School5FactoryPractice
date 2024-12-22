using Microsoft.Extensions.DependencyInjection;
using School5FactoryPractice.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace School5FactoryPractice
{
    /// <summary>
    /// Interaction logic for MainStudentPage.xaml
    /// </summary>
    public partial class MainStudentPage : Page
    {
        public MainStudentPage(List<string> _currentUserData, User _currentUser)
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

            if (parentWindow != null)
            {
                parentWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                parentWindow.Topmost = true;
            }

            _usersData = _currentUserData;
            _currentStudentUser = _currentUser;

            using(ApplicationContext db = new ApplicationContext())
            {
                var _currentStudentUserInfo = db.Users.FirstOrDefault(u => u.UserId == _currentStudentUser.UserId);

                if(_currentStudentUserInfo != null)
                {
                    TB_CurrentUser.Text = $"Привет! {_currentStudentUser.Name} Хорошего обучения!";
                }
            }
        }

        List<string> _usersData;
        User _currentStudentUser;

        bool _isFirstClicked = false;

        private void ME_Background_MediaEnded(object sender, RoutedEventArgs e)
        {
            var _firstBackgroundPath = "src\\background.mp4";
            var _secBackgroundPath = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _firstBackgroundPath));

            ME_Background.Source = _secBackgroundPath;
            ME_Background.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (!_isFirstClicked)
            {
                _isFirstClicked = true;

                if (parentWindow != null)
                {
                    parentWindow.WindowState = WindowState.Maximized;
                    parentWindow.WindowStyle = WindowStyle.None;
                    parentWindow.Topmost = true;
                }
            }
            else
            {
                _isFirstClicked = false;
                if (parentWindow != null)
                {
                    parentWindow.WindowState = WindowState.Normal;
                    parentWindow.WindowStyle = WindowStyle.None;
                    parentWindow.Topmost = true;
                }
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.WindowState = WindowState.Minimized;
                parentWindow.WindowStyle = WindowStyle.None;
                parentWindow.Topmost = true;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Lbl_StudentPick.Visibility = Visibility.Collapsed;
            StudentFrame.Visibility = Visibility.Visible;

            StudentFrame.Navigate(new StudentInfo(_usersData, _currentStudentUser));
        }

        private void IMG_Logout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://resh.edu.ru/",
                UseShellExecute = true
            });
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Lbl_StudentPick.Visibility = Visibility.Collapsed;
            StudentFrame.Visibility = Visibility.Visible;

            StudentFrame.Navigate(new StudentHomework(_currentStudentUser));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Lbl_StudentPick.Visibility = Visibility.Collapsed;
            StudentFrame.Visibility = Visibility.Visible;

            StudentFrame.Navigate(new StudentGrades(_currentStudentUser));
        }
    }
}
