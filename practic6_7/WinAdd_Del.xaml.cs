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
    /// Логика взаимодействия для WinAdd_Del.xaml
    /// </summary>
    public partial class WinAdd_Del : Window
    {
        public WinAdd_Del()
        {
            InitializeComponent();
            dgWork.ItemsSource = _db.GetContext().work.ToList();
        }
       
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Hide();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new WinAdd().Show();
            Hide();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var clientForRemoving = dgWork.SelectedItems.Cast<work>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    _db.GetContext().work.RemoveRange(clientForRemoving);
                    _db.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    dgWork.ItemsSource = _db.GetContext().work.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
