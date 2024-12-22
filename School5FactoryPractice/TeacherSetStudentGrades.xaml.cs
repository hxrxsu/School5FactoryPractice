using School5FactoryPractice.Data;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for TeacherSetStudentGrades.xaml
    /// </summary>
    public partial class TeacherSetStudentGrades : Page
    {
        public TeacherSetStudentGrades()
        {
            InitializeComponent();

            using (ApplicationContext db = new ApplicationContext())
            {
                var _existingUserStudentWithHSub = db.HomeworkSubs.Where(h => h.StudentId != null);

                if (_existingUserStudentWithHSub != null)
                {
                    foreach (var _subs in _existingUserStudentWithHSub)
                    {
                        LB_Homework.Items.Add($"{_subs.HomeworkSubscriptionId}\n{_subs.HomeworkName}\n{_subs.HomeworkRemainingTime}\nЗакреплено за учеником с номером - {_subs.StudentId}");
                    }
                }
                else { MessageBox.Show("Похоже на данный момент в системе нет ни одного ученика!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error); }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var _selectedItem = LB_Homework.SelectedItem.ToString();
                var _idFromLB = _selectedItem.Substring(0, _selectedItem.Length - _selectedItem.Length + 1);
                var _selectedUser = db.Users.FirstOrDefault(u => u.UserId == Convert.ToInt32(_idFromLB));
                var _checkedIdFromLBAndHS = db.HomeworkSubs.FirstOrDefault(u => u.StudentId.Equals(_selectedUser.UserId));

                var _existingStudentWithHSub = db.HomeworkSubs.FirstOrDefault(h => h.StudentId == _selectedUser.UserId);

                _existingStudentWithHSub.Grades.Add(Convert.ToInt32(TB_Grade.Text));

                MessageBox.Show("Вы успешно поставили оценку за ДЗ");
            }
        }

        private void LB_Homework_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LB_Homework.SelectedIndex >= 0)
            {
                try
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var _selectedItem = LB_Homework.SelectedItem.ToString();
                        var _idFromLB = _selectedItem.Substring(0, _selectedItem.Length - _selectedItem.Length + 1);
                        var _selectedUser = db.Users.FirstOrDefault(u => u.UserId == Convert.ToInt32(_idFromLB));
                        var _checkedIdFromLBAndHS = db.HomeworkSubs.FirstOrDefault(u => u.StudentId.Equals(_selectedUser.UserId));

                        if (_checkedIdFromLBAndHS != null)
                        {
                            string tempFilePath = System.IO.Path.GetTempFileName() + ".pdf";
                            File.WriteAllBytes(tempFilePath, _checkedIdFromLBAndHS.SolvedHomework);

                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tempFilePath) { UseShellExecute = true });
                        }
                        else
                        {
                            MessageBox.Show("Домашнее задание не найдено или не сохранено.");
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show($"{ex}"); }

            }
        }
    }
}
