using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Win32;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using School5FactoryPractice.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Interaction logic for StudentHomework.xaml
    /// </summary>
    public partial class StudentHomework : Page
    {
        public StudentHomework(User _currentUser)
        {
            InitializeComponent();

            _currentStudentUser = _currentUser;

            using (ApplicationContext db = new ApplicationContext())
            {
                var _currentStudentHomework = db.HomeworkSubs.FirstOrDefault(h => h.StudentId == _currentUser.UserId);

                TB_CurrentStudentHomework.Text = $"Твое ДЗ - {_currentStudentHomework.HomeworkName}\nДо какого числа нужно сделать - {_currentStudentHomework.HomeworkRemainingTime}";
            }
        }

        User _currentStudentUser;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "PDF Files (*.pdf)|*.pdf";

            if (ofd.ShowDialog() == true)
            {
                string _filePath = ofd.FileName;

                // Чтение PDF-документа в массив байтов
                byte[] pdfBytes = File.ReadAllBytes(_filePath);

                using (ApplicationContext db = new ApplicationContext())
                {
                    var _currentStudentHomework = db.HomeworkSubs.FirstOrDefault(h => h.StudentId == _currentStudentUser.UserId);

                    if (_currentStudentHomework != null)
                    {
                        _currentStudentHomework.SolvedHomework = pdfBytes;
                        db.SaveChanges();
                        MessageBox.Show("Домашнее задание успешно сохранено.");
                    }
                    else
                    {
                        MessageBox.Show("Домашнее задание не найдено.");
                    }
                }
            }
        }
    }
}
