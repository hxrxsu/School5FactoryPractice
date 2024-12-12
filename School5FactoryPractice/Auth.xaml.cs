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
using System.IO;

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
        }

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
    }
}
