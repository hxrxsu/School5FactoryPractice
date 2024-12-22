using School5FactoryPractice.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml;

namespace School5FactoryPractice
{
    /// <summary>
    /// Interaction logic for TeacherSetHomework.xaml
    /// </summary>
    public partial class TeacherSetHomework : Page
    {
        public TeacherSetHomework()
        {
            InitializeComponent();

            using (ApplicationContext db = new ApplicationContext())
            {
                if(db.Users.Where(u => u.Role == "Ученик") != null)
                {
                    foreach (var _user in db.Users.Where(u => u.Role == "Ученик"))
                    {
                        LB_Students.Items.Add($"{_user.UserId} {_user.Name}");
                    }
                }
                else { MessageBox.Show("Похоже на данный момент в системе нет ни одного ученика!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TB_Homework.Text) || !DP_RemainingTime.SelectedDate.HasValue || LB_Students.SelectedItem == null)
            {
                MessageBox.Show("Выберите ученика, напишите в домашнее задание в соответствующее окно и выберите до какого числа его нужно сделать", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using(ApplicationContext db = new ApplicationContext())
                {
                    var _selectedItem = LB_Students.SelectedItem.ToString();
                    var _idFromLB = _selectedItem.Substring(0, _selectedItem.Length - _selectedItem.Length + 1);

                    var _selectedUser = db.Users.FirstOrDefault(u => u.UserId == Convert.ToInt32(_idFromLB));

                    var _existingHomework = db.HomeworkSubs.FirstOrDefault(u => u.StudentId.Equals(_selectedUser.UserId));

                    HomeworkSubscription hs = new HomeworkSubscription
                    {
                        StudentId = _selectedUser.UserId,
                        HomeworkName = TB_Homework.Text,
                        HomeworkRemainingTime = DP_RemainingTime.SelectedDate.Value,
                    };

                    if (_existingHomework != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Текущее ДЗ уже назначено. Хотите переназначить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
                        
                        if(result == MessageBoxResult.Yes)
                        {

                            db.HomeworkSubs.Remove(_existingHomework);
                            db.HomeworkSubs.Add(hs);

                            MessageBox.Show($"Вы успешно переназначили ученику ДЗ на - {hs.HomeworkName}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Вы успешно назначили ученику ДЗ - {hs.HomeworkName}");

                        db.HomeworkSubs.Add(hs);

                    }
                    TB_SelectedStudentHomework.Text = $"Текущее домашнее задание - {hs.HomeworkName}\nДо какого числа нужно сдать - {hs.HomeworkRemainingTime}";
                    db.SaveChanges();
                }
            }
        }

        private void LB_Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(LB_Students.SelectedIndex >= 0)
            {
                try
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var _selectedItem = LB_Students.SelectedItem.ToString();
                        var _idFromLB = _selectedItem.Substring(0, _selectedItem.Length - _selectedItem.Length + 1);
                        var _selectedUser = db.Users.FirstOrDefault(u => u.UserId == Convert.ToInt32(_idFromLB));
                        var _checkedIdFromLBAndHS = db.HomeworkSubs.FirstOrDefault(u => u.StudentId.Equals(_selectedUser.UserId));

                        if(_checkedIdFromLBAndHS != null)
                        {
                            TB_SelectedStudentHomework.Text = $"Текущее домашнее задание - {_checkedIdFromLBAndHS.HomeworkName}\nДо какого числа нужно сдать - {_checkedIdFromLBAndHS.HomeworkRemainingTime}";
                        }
                        else { TB_SelectedStudentHomework.Text = ""; }
                    }
                }
                catch (Exception ex) { MessageBox.Show($"{ex}"); }
            }
        }
        private void TB_Homework_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Homework.Text = "";
        }
    }
}
    