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
            WinFrame.Navigate(new CreateSchemePage());
        }

        private void CreateSchemeClick(object sender, RoutedEventArgs e)
        {
            WinFrame.Navigate(new CreateSchemePage());
        }

        private void ShowScheme(object sender, RoutedEventArgs e)
        {
           
            SchemeWindow schemeWindow = new SchemeWindow();
           schemeWindow.Show();
           
        }

        private void EnterValuesClick(object sender, RoutedEventArgs e)
        {
            WinFrame.Navigate(new EnterValuesPage());
        }
    }
}
