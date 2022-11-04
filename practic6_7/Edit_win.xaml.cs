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
using static System.Data.Entity.Infrastructure.Design.Executor;
using _db = practic6_7.practicEntities;

namespace practic6_7
{
    /// <summary>
    /// Логика взаимодействия для Edit_win.xaml
    /// </summary>
    public partial class Edit_win : Window
    {
        private razmer _razmer;
        public Edit_win(object button)
        {
            InitializeComponent();
            DataContext = (button as Button).DataContext;
            _razmer = (razmer)DataContext;
            tbHeight.Text = _razmer.height.ToString();
            tbWidth.Text = _razmer.width.ToString();
            tbGlubina.Text = _razmer.glubina.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(tbHeight.Text))
                errors.AppendLine("Укажите высоту");
            if (string.IsNullOrEmpty(tbWidth.Text))
                errors.AppendLine("Укажите ширину");
            if (string.IsNullOrEmpty(tbGlubina.Text))
                errors.AppendLine("Укажите глубину");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                try
                {
                    _razmer.height = int.Parse(tbHeight.Text);
                    _razmer.width = int.Parse(tbWidth.Text);
                    _razmer.glubina = int.Parse(tbGlubina.Text);

                    _db.GetContext().SaveChanges();
                    new WinEdit().Show();
                    Hide();
                }
                catch { MessageBox.Show("Неверный формат данных"); }
               

            }

        }
    }
}
