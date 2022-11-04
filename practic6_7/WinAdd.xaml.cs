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
using System.Windows.Shapes;
using _db = practic6_7.practicEntities;

namespace practic6_7
{
    /// <summary>
    /// Логика взаимодействия для WinAdd.xaml
    /// </summary>
    public partial class WinAdd : Window
    {
        public WinAdd()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(tbKind.Text))
                errors.AppendLine("Укажите вид работы");
            if (string.IsNullOrEmpty(dpDateCreate.Text))
                errors.AppendLine("Укажите дату создания");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                try
                { 
                _db.GetContext().work.Add(new work { kind_material = tbKind.Text, date_create = dpDateCreate.SelectedDate.Value });
                _db.GetContext().SaveChanges();
                MessageBox.Show("Успешно!");
                new WinAdd_Del().Show();
                Hide();
            }
            catch { MessageBox.Show("Неверный тип данных!"); }
        }
    }
}
