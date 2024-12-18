using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for MainStudentPage.xaml
    /// </summary>
    public partial class MainStudentPage : Page
    {
        public MainStudentPage()
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
    }
}
