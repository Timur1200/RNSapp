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
using RNSapp.Service;

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
        private double P = 1;
        private int _currentIndex = 1;
        private void Calc()
        {
            List<Elem> list = new List<Elem>(); 
            foreach (var item in Scheme._thisScheme.elems)
            {
                if (item.Index == 0)
                {
                    P = P * item.law.P();
                }
                else
                {
                    if (_currentIndex == item.Index)
                    {
                        list.Add(item);
                    }
                    else
                    {
                        P = P * Elem.Psys(list);
                        list = new List<Elem>();
                        list.Add(item);
                        _currentIndex = item.Index;
                    }
                }
            }
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
            sb.AppendLine();
            sb.AppendLine();
            Calc();
            sb.AppendLine("Вероятность безотказной работы системы:" + P);
            double q = (double)1.00 - (double)P;
            sb.AppendLine("Вероятность отказа работы системы:" + (double)q);

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
