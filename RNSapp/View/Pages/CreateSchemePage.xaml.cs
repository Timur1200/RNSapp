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

namespace RNSapp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateSchemePage.xaml
    /// </summary>
    public partial class CreateSchemePage : Page
    {
        public CreateSchemePage()
        {
            InitializeComponent();
            abcdY(100);
            

          // CreateRectangle();


        }                        //                        |--|
        int Ax = 20; int Ay = 20;// прямоугольник 1 точка  |BC|
        int Bx = 20; int By = 50;// 2                      |AD|
        int Cx = 70; int Cy = 50;// 3                      |--|
        int Dx = 70; int Dy = 20;// 4

        int Ex = 20; int Ey = 35; // линия FE
        int Fx = 0; int Fy = 35;  // перед фигурой  
        int tBlockX = 45; // надпись
        int tBlockY = 35; //
        int number = 1; //  номер элемента


        private void CreateRectangle(int ax,int ay,int bx, int by, int cx,int cy,int dx,int dy,int fx,int fy,int ex,int ey,int x,int y)
        {
            Add(CreateLine(ax, ay, bx, by));
            Add(CreateLine(dx, dy, cx, cy));
            Add(CreateLine(ax, ay, dx, dy));
            Add(CreateLine(bx, by, cx, cy));
            Add(CreateLine(fx, fy, ex, ey)); // линия
            TextBlock textBlock = new TextBlock();
            textBlock.Text = number.ToString();
            NumberElement();
            textBlock.Padding = new Thickness(x, y, 0, 0);
            Add(textBlock);
            




        }

        private Line CreateLine(double x1, double y1, double x2, double y2)
        {
            Line line = new Line();
            line.X1 = x1; line.Y1 = y1;
            line.X2= x2; line.Y2 = y2;
            line.Stroke = Brushes.Black;
            return line;
        }
        private void Add(UIElement e)
        {
            SchemeGrid.Children.Add(e);
        }
        private void abcdY(int y)
        {
            Ay = Ay + y;
            By = By + y;
            Cy = Cy + y;
            Dy = Dy + y;
            tBlockY += y;
            Ey = Ey + y;
            Fy= Fy + y;
        }
        private void abcdX(int x)
        {
            tBlockX = tBlockX + x;
            Ax = Ax + x;
            Bx = Bx + x;
            Cx = Cx + x;
            Dx = Dx + x;
            Ex = Ex + x;
            Fx = Fx + x;
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (RBtn1Serial.IsChecked.Value)
            {
                
                Add(CreateLine(Ax, Ay, Bx, By));
                Add(CreateLine(Dx, Dy, Cx, Cy));
                Add(CreateLine(Ax, Ay, Dx, Dy));
                Add(CreateLine(Bx, By, Cx, Cy));
                Add(CreateLine(Fx, Fy, Ex, Ey)); // линия
                TextBlock textBlock = new TextBlock();
                textBlock.Text = number.ToString();
                NumberElement();
                textBlock.Padding = new Thickness(tBlockX, tBlockY, 0, 0);
                Add(textBlock);
                

            }
            else
            {
                int NumBranches;
                int.TryParse(TBoxNumberOfBranches.Text, out NumBranches);
                if (NumBranches <= 1)
                {
                    MessageBox.Show("Так нельзя!");
                    return;
                }
                int a = (NumBranches - 1) / 2;
                bool b = false;
                if (NumBranches % 2 == 0)
                {
                 //   b = true;
                }
                int up = a + Convert.ToInt32(b);
                

                int i = 0;
                int ax = Ax;int ay = Ay;int bx = Bx;int by = By;int cx = Cx;int cy = Cy;int dx = Dx;int dy = Dy;
                int ex = Ex;int ey = Ey;int fx = Fx;int fy = Fy;int tx = tBlockX;int ty = tBlockY;
                MessageBox.Show($"{up}");
                
                ay = ay + 50 * up; fy = fy + 50 * up; ty = ty + 50 * up;
                by = by + 50 * up; cy = cy + 50 * up; dy = dy + 50 * up; ey = ey + 50 * up;
                // up = up - 1;
                //up = 1;
                //ax = ax + 70 * up;
                //bx = bx + 70 * up;
                //cx = cx + 70 * up;
                //dx = dx + 70 * up;
                //ex = ex + 70 * up;
                //fx = fx + 70 * up;
                //tx = tx + 70 * up;
                while (NumBranches != i)
                {
                    i++;
                    
                    CreateRectangle(ax,ay,bx,by,cx,cy,dx,dy,fx,fy,ex,ey,tx,ty);
                    ay = ay - 50;by = by - 50;cy=cy - 50;dy= dy- 50;ey = ey - 50;fy= fy - 50;
                    ty = ty - 50;
                }
                
            }
            abcdX(70);
        }

       
        private void NumberElement()
        {
            number += 1;
            TBoxNumberElement.Text = number.ToString();
        }
        

        private void RbtnsClick(object sender, RoutedEventArgs e)
        {
            if (RBtn1Serial.IsChecked== true)
            {
                TBoxNumberOfBranches.IsEnabled = false;
            }
            else
            {
                TBoxNumberOfBranches.IsEnabled = true;
            }
        }
    }
}
