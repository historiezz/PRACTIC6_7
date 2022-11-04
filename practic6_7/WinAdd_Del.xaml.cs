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
using word = Microsoft.Office.Interop.Word;

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

        private void btnExtoPDF_Click(object sender, RoutedEventArgs e)
        {
            var works = _db.GetContext().work.ToList();
            var application = new word.Application();
            word.Document document = application.Documents.Add();

            foreach (var work in works)
            {
                word.Paragraph paragraph = document.Paragraphs.Add();
                word.Range worksRange = paragraph.Range;
                worksRange.Text = work.id.ToString();
                paragraph.set_Style("Заголовок 2");
                worksRange.InsertParagraphAfter();

                word.Paragraph tableparagraph = document.Paragraphs.Add();
                word.Range tableRange = tableparagraph.Range; ;
                word.Table worktable = document.Tables.Add(tableRange, works.Count() + 1, 3);
                worktable.Borders.InsideLineStyle = worktable.Borders.OutsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                worktable.Range.Cells.VerticalAlignment = word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                word.Range cellRange;

                cellRange = worktable.Cell(1, 1).Range;
                cellRange.Text = "Id";
                cellRange = worktable.Cell(1, 2).Range;
                cellRange.Text = "Вид материала";
                cellRange = worktable.Cell(1, 3).Range;
                cellRange.Text = "Дата создания:";

                worktable.Rows[1].Range.Bold = 1;
                worktable.Rows[1].Range.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;

                for (int i = 0; i < works.Count(); i++)
                {
                    var currentWorks = works[i];

                    cellRange = worktable.Cell(i + 2, 1).Range;
                    cellRange.Text = currentWorks.id.ToString();
                    cellRange = worktable.Cell(i + 2, 2).Range;
                    cellRange.Text = currentWorks.kind_material;
                    cellRange = worktable.Cell(i + 2, 3).Range;
                    cellRange.Text = currentWorks.date_create.ToString();
                }

                if (work != works.LastOrDefault())
                    document.Words.Last.InsertBreak(word.WdBreakType.wdPageBreak);

                document.SaveAs2(@"C:\Users\Данил\Desktop\учеба\Doc.pdf", word.WdExportFormat.wdExportFormatPDF);
            }
        }
    }
}
