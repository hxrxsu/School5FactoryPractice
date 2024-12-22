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
    /// Interaction logic for TeacherInfo.xaml
    /// </summary>
    public partial class TeacherInfo : Page
    {
        public TeacherInfo(List<string> _currentUsersData, User _currentUser)
        {
            InitializeComponent();

            TB_Email.Text = _currentUser.Email;
            TB_PhoneNumber.Text = Convert.ToString(_currentUser.PhoneNumber);
            TB_Login.Text = _currentUser.Login;
            TB_Pass.Text = _currentUser.Password;

            _currentStudentUser = _currentUser;
        }

        User _currentStudentUser;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    var _foundUser = db.Users.FirstOrDefault(u => u.UserId == _currentStudentUser.UserId);

                    if (_foundUser != null)
                    {
                        _foundUser.Email = TB_Email.Text;
                        _foundUser.PhoneNumber = Convert.ToInt64(TB_PhoneNumber.Text);
                        _foundUser.Login = TB_Login.Text;
                        _foundUser.Password = TB_Pass.Text;
                    }

                    db.SaveChanges();
                    MessageBox.Show("Данные изменены успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex) { MessageBox.Show("Попробуйте ввести номер телефона в корректном формате! 80000000000", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error); }

            }
        }
    }
}
