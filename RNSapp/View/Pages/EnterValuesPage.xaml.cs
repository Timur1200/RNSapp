using RNSapp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace RNSapp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EnterValuesPage.xaml
    /// </summary>
    public partial class EnterValuesPage : Page
    {
        public EnterValuesPage()
        {
            InitializeComponent();
            offAllTextBox();
        }
        int count=0;
        public static List<Elem> elemLaws { get; set; }
        private Elem _item;
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            int schemeCount = Scheme._thisScheme.Number;
            if (count != schemeCount)
            {
                //elemLaws= new List<Elem>();
                LBoxElement.ItemsSource = null;
                count = Scheme._thisScheme.Number;
                //for (int i = 1; i != count + 1; i++)
                //{
                //    //elemLaws.Add(new Elem(i));

                //}
                elemLaws = Scheme._thisScheme.elems;
                LBoxElement.ItemsSource = Scheme._thisScheme.elems;
            }
            
            if (count == 0)
            {
                MessageBox.Show("Необходимо добавить элементы в схему!");
                return;
            }
            
            
        }
   
        private void BaseRbtnClick()
        {
            if (LBoxElement.SelectedItem == null) return;
            if (Normal.IsChecked.Value) 
            {   
                if (_item.law is NormalLaw == false) _item.law = new NormalLaw();
            }
            if (Exp.IsChecked.Value) 
            {
               if (_item.law is ExpLaw == false) _item.law = new ExpLaw(); 
            }
            if (Weibul.IsChecked.Value)
            {
                if (_item.law is WeibullLaw == false) _item.law = new WeibullLaw();
            }
            if (Poisson.IsChecked.Value) 
            {
                if (_item.law is PoissonLaw == false) _item.law = new PoissonLaw(); 
            }
        }
        private void IsCheckNull()
        {
            Normal.IsChecked = false;
            Exp.IsChecked = false;
            Weibul.IsChecked = false;
            Poisson.IsChecked = false;
        }

        private void SelectedItemListBoxClick(object sender, SelectionChangedEventArgs e)
        {
            if (LBoxElement.SelectedItem == null)
            {
                offAllTextBox();
                return;
            }
            var i = LBoxElement.SelectedItem as Elem;
            _item = i;
            if (_item.law == null) 
            { 
                IsCheckNull();
            }

            if (_item.law is ExpLaw)
            {
                Exp.IsChecked = true;
                Exp_Click(null, null);
                TimeTextBox.Text = ((ExpLaw)_item.law).t.ToString();
                LambdaTBox.Text = ((ExpLaw)_item.law).Lambda.ToString();
               
               
            }
            if (_item.law is WeibullLaw)
            {
                Weibul.IsChecked = true;
                Weibul_Click(null, null);
                aTBox.Text = ((WeibullLaw)_item.law).a.ToString();
                bTBox.Text = ((WeibullLaw)_item.law).b.ToString();
                TimeTextBox.Text = ((WeibullLaw)_item.law).t.ToString();
               
               
            }
            if (_item.law is NormalLaw) 
            {
                Normal.IsChecked = true;
                Normal_Click(null, null);
                SigmaTBox.Text = ((NormalLaw)_item.law).sigma.ToString();
                MatemMTBox.Text = ((NormalLaw)_item.law).T0.ToString();
                TimeTextBox.Text = ((NormalLaw)_item.law).t.ToString();
                
               
            }
            if (_item.law is PoissonLaw)
            {
                Poisson.IsChecked = true;
                Poisson_Click(null, null);
                avgTBox.Text = ((PoissonLaw)_item.law).a.ToString();
                rTBox.Text = ((PoissonLaw)_item.law).r.ToString();
               
               
            }



        }
        /// <summary>
        /// Выключает все TextBox'ы
        /// </summary>
        void offAllTextBox()
        {
            var i = _item;
            _item = null;
            foreach (UIElement element in TBoxStackPanel.Children)
            {
                
                if (element is TextBox)
                {
                    ((TextBox)element).Visibility = Visibility.Collapsed;
                    ((TextBox)element).Text = "";
                }
            }
            _item = i;
            foreach (UIElement element in TextStackPanel.Children)
            {
                if (element is TextBlock)
                {
                    ((TextBlock)element).Visibility = Visibility.Collapsed;
                }
            }
        }

        #region Когда нажимают на radion button
        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            if (LBoxElement.SelectedItem == null) return;
            BaseRbtnClick();
            offAllTextBox();
            SigmaTBox.Visibility = Visibility.Visible;SigmaText.Visibility= Visibility.Visible;
            TimeTextBox.Visibility = Visibility.Visible;TimeText.Visibility= Visibility.Visible;
            MatemMTBox.Visibility = Visibility.Visible;MatemMText.Visibility= Visibility.Visible;
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            if (LBoxElement.SelectedItem == null) return;
            BaseRbtnClick();
            offAllTextBox();
            LambdaTBox.Visibility = Visibility.Visible;LambdaText.Visibility= Visibility.Visible;
            TimeTextBox.Visibility = Visibility.Visible;TimeText.Visibility = Visibility.Visible;
        }

        private void Poisson_Click(object sender, RoutedEventArgs e)
        {
            if (LBoxElement.SelectedItem == null) return;
            BaseRbtnClick();
            offAllTextBox();
            avgTBox.Visibility = Visibility.Visible;avgText.Visibility= Visibility.Visible;
            rTBox.Visibility = Visibility.Visible;rText.Visibility = Visibility.Visible;

        }

        private void Weibul_Click(object sender, RoutedEventArgs e)
        {
            if (LBoxElement.SelectedItem == null) return;
            BaseRbtnClick();
            offAllTextBox();
            aTBox.Visibility = Visibility.Visible;aText.Visibility= Visibility.Visible;
            bTBox.Visibility = Visibility.Visible;bText.Visibility = Visibility.Visible;
            TimeTextBox.Visibility = Visibility.Visible;TimeText.Visibility= Visibility.Visible;
        }
        #endregion
        #region TextBox можно писать только числа и числа с плавающей запятой
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex("[^0-9,-]+");

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        #endregion

        #region Focus всех TextBox записывает значение, когда спадает фокус
        private void TimeText_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0) return;
            double t = Convert.ToDouble((sender as TextBox).Text);
            if (_item.law is NormalLaw) ((NormalLaw)_item.law).t = t;
            if (_item.law is WeibullLaw) ((WeibullLaw)_item.law).t = t;
            if (_item.law is ExpLaw) ((ExpLaw)_item.law).t = t;
        }

        private void SigmaTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0) return;
            double t = Convert.ToDouble((sender as TextBox).Text);
            if (_item.law is NormalLaw) ((NormalLaw)_item.law).sigma = t;
        }

        private void MatemMTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0) return;
            double t = Convert.ToDouble((sender as TextBox).Text);
            if (_item.law is NormalLaw) ((NormalLaw)_item.law).T0 = t;
        }

        private void LambdaTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0) return;
            double t = Convert.ToDouble((sender as TextBox).Text);
            if (_item.law is ExpLaw) ((ExpLaw)_item.law).Lambda = t;
        }

        private void aTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0) return;
            double t = Convert.ToDouble((sender as TextBox).Text);
            if (_item.law is WeibullLaw) ((WeibullLaw)_item.law).a = t;
        }

        private void bTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0) return;
            double t = Convert.ToDouble((sender as TextBox).Text);
            if (_item.law is WeibullLaw) ((WeibullLaw)_item.law).b = t;
        }

        private void avgTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0) return;
            double t = Convert.ToDouble((sender as TextBox).Text);
            if (_item.law is PoissonLaw) ((PoissonLaw)_item.law).a = t;
        }

        private void rTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0) return;
            double t = Convert.ToDouble((sender as TextBox).Text);
            if (_item.law is PoissonLaw) ((PoissonLaw)_item.law).r = t;
        }
        #endregion
    }
}
