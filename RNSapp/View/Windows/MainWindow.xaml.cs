using RNSapp.Service;
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
using RNSapp.View.Pages;
using RNSapp.View;
using System.Drawing;
using RNSapp.View.Windows;

namespace RNSapp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameStore.MainFrame = WinFrame;
            ShowSchemeBtn.IsEnabled = false;
            EnterValuesBtn.IsEnabled = false;
            ResultBtn.IsEnabled = false;
            
        }
        CreateSchemePage _thisScheme;
        public EnterValuesPage _enterValuesPage;
        ResultPage _resultPage;
        private void CreateSchemeClick(object sender, RoutedEventArgs e)
        {
            _thisScheme = new CreateSchemePage();
            WinFrame.Navigate(_thisScheme);
            _enterValuesPage = new EnterValuesPage();
            ShowSchemeBtn.IsEnabled = true;
            EnterValuesBtn.IsEnabled = true;
        }

        private void ShowScheme(object sender, RoutedEventArgs e)
        {
            WinFrame.Navigate(_thisScheme);
        }

        private void EnterValuesClick(object sender, RoutedEventArgs e)
        {
            WinFrame.Navigate(_enterValuesPage);
            ResultBtn.IsEnabled = true;
        }

        private void ResultClick(object sender, RoutedEventArgs e)
        {
            var items = EnterValuesPage.elemLaws;

            foreach (var item in items)
            {
                if (item.IsReady() == false)
                {
                    MessageBox.Show("Нужно заполнить все необходимые поля");
                    return;
                }
            }
            _resultPage = new ResultPage();
            WinFrame.Navigate(_resultPage);
        }
    }
}
