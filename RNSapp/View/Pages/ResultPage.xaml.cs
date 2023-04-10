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
using WinForm = System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RNSapp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var elems = EnterValuesPage.elemLaws;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Результаты расчета:");
            sb.AppendLine("Число элементов в системе: - " + elems.Count);
            sb.AppendLine();
            sb.AppendLine();
            foreach (var item in elems)
            {
               sb.AppendLine( item.law.Run(item.Id).ToString());
            }

            WinForm.SaveFileDialog saveFileDialog1 = new WinForm.SaveFileDialog();
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog1.Title = "Сохранить результаты расчётов";

            if (saveFileDialog1.ShowDialog() == WinForm.DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.Write(sb.ToString());
                }
                //MessageBox.Show(saveFileDialog1.FileName);
                using (StreamReader sr = new StreamReader(saveFileDialog1.FileName))
                {
                    ResultTextBox.Text = sr.ReadToEnd();
                }
            }
           
        }
    }
}
