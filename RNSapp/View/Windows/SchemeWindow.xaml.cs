using RNSapp.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace RNSapp.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для SchemeWindow.xaml
    /// </summary>
    public partial class SchemeWindow : Window
    {
        public SchemeWindow()
        {
            InitializeComponent();
            Scheme._thisScheme.ElementsToScheme();
            foreach(var item in Scheme._thisScheme.UIelements)
            {
                SchemeGrid.Children.Add(item);
            }
            
            

           
        }
        private void Screen()
        {
            double screenLeft = this.Left + 9;//SystemParameters.VirtualScreenLeft;
            double screenTop = this.Top + 30;//SystemParameters.VirtualScreenTop;
            double screenWidth = this.Width;//SystemParameters.VirtualScreenWidth;
            double screenHeight = this.Height;//SystemParameters.MaximizedPrimaryScreenHeight;//SystemParameters.VirtualScreenHeight;
            using (Bitmap bmp = new Bitmap((int)screenWidth, (int)screenHeight))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    //string filename = FIO.Text + ".png";
                    Opacity = 0;
                    var time = DateTime.Now;
                    g.CopyFromScreen((int)screenLeft, (int)screenTop, 18, 39, /*(int)screenWidth,(int) screenHeight,*/ bmp.Size);
                    bmp.Save($"{time.ToString("d")} - {time.ToString("fff")}.png");
                    Opacity = 1;
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Closed(object sender, EventArgs e)
        {
Screen();
        }
    }
}
