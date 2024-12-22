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
    /// Interaction logic for StudentGrades.xaml
    /// </summary>
    public partial class StudentGrades : Page
    {
        public StudentGrades(User _currentUser)
        {
            InitializeComponent();

            using (ApplicationContext db = new ApplicationContext())
            {
                var _existingSubs = db.HomeworkSubs.FirstOrDefault(h => h.StudentId == _currentUser.UserId);

                if (_existingSubs != null && _existingSubs.Grades.Any())
                {
                    LB_Grades.ItemsSource = _existingSubs.Grades;

                    double averageGrade = _existingSubs.Grades.Average();
                    LBL_AverageGrade.Content = $"Средний балл: {averageGrade:F2}";
                }
                else
                {
                    LBL_AverageGrade.Content = "Оценки не найдены.";
                }
            }
        }
    }
}
