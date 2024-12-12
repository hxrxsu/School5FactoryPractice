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

            try
            {
                IE_Teacher.Source = new BitmapImage(_secImageTeacherPath);
                IE_Student.Source = new BitmapImage(new Uri(_secImageStudentPath, UriKind.Relative));
            }
            catch (Exception ex) { MessageBox.Show($"{ex}"); }

            HideObjects();
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
            Application.Current.Shutdown();
        }

        private void HideObjects()
        {
            TB_Email.Visibility = Visibility.Hidden;
            TB_FIO.Visibility = Visibility.Hidden;
            TB_Login.Visibility = Visibility.Hidden;
            TB_Name.Visibility = Visibility.Hidden;
            TB_Pass.Visibility = Visibility.Hidden;
            TB_PhoneNumber.Visibility = Visibility.Hidden;
            BN_Reg.Visibility = Visibility.Hidden;
            LL_ToAuth.Visibility = Visibility.Hidden;
        }
        private void UnHideObjects()
        {
            TB_Email.Visibility = Visibility.Visible;
            TB_FIO.Visibility = Visibility.Visible;
            TB_Login.Visibility = Visibility.Visible;
            TB_Name.Visibility = Visibility.Visible;
            TB_Pass.Visibility = Visibility.Visible;
            TB_PhoneNumber.Visibility = Visibility.Visible;
            BN_Reg.Visibility = Visibility.Visible;
            LL_ToAuth.Visibility = Visibility.Visible;
        }
    }
}
