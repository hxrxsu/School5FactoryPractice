﻿using System;
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
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
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
        }

        private void ME_Background_MediaEnded(object sender, RoutedEventArgs e)
        {
            var _firstBackgroundPath = "src\\background.mp4";
            var _secBackgroundPath = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _firstBackgroundPath));

            ME_Background.Source = _secBackgroundPath;
            ME_Background.Play();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void IE_Student_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegStudent());
        }

        private void IE_Teacher_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegTeacher());
        }

        private void BN_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
