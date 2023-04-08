using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;


namespace RNSapp.Service
{
    internal class Scheme
    {
        public Scheme() 
        {
            abcdY(150);
        }
        //                        |--|
        int Ax = 20; int Ay = 20;// прямоугольник 1 точка  |BC|
        int Bx = 20; int By = 50;// 2                      |AD|
        int Cx = 70; int Cy = 50;// 3                      |--|
        int Dx = 70; int Dy = 20;// 4

        int Ex = 20; int Ey = 35; // линия FE
        int Fx = 0; int Fy = 35;  // перед фигурой  
        int tBlockX = 45; // надпись
        int tBlockY = 35; //
       public int number = 1; //  номер элемента
        public List<UIElement> UIelements= new List<UIElement>();
        public List<Element> Elements = new List<Element>();
        public static Scheme _thisScheme = new Scheme();
        public void AddClick(bool IsSerial,Element elem)
        {
            if (IsSerial)
            {

                Add(CreateLine(Ax, Ay, Bx, By));
                Add(CreateLine(Dx, Dy, Cx, Cy));
                Add(CreateLine(Ax, Ay, Dx, Dy));
                Add(CreateLine(Bx, By, Cx, Cy));
                Add(CreateLine(Fx, Fy, Ex, Ey)); // линия
                Add(CreateLine(Fx + 70, Fy, Ex + 70, Ey)); // линия 2
                TextBlock textBlock = new TextBlock();
                textBlock.Text = number.ToString();
                NumberElement();
                textBlock.Padding = new Thickness(tBlockX, tBlockY, 0, 0);
                Add(textBlock);


            }
            else
            {
                int NumBranches = elem.Branches;
               
                int a = (NumBranches - 1) / 2;
                bool b = false;
                
                int up = a + Convert.ToInt32(b);
                abcdX(20);

                int i = 0;
                int ax = Ax; int ay = Ay; int bx = Bx; int by = By; int cx = Cx; int cy = Cy; int dx = Dx; int dy = Dy;
                int ex = Ex; int ey = Ey; int fx = Fx; int fy = Fy; int tx = tBlockX; int ty = tBlockY;


                ay = ay + 50 * up; fy = fy + 50 * up; ty = ty + 50 * up;
                by = by + 50 * up; cy = cy + 50 * up; dy = dy + 50 * up; ey = ey + 50 * up;

                int max = 0;
                int min = 0;
                while (NumBranches != i)
                {
                    if (i == 0)
                    {
                        max = fy;
                    }
                    i++;

                    CreateRectangle(ax, ay, bx, by, cx, cy, dx, dy, fx, fy, ex, ey, tx, ty);
                    ay = ay - 50; by = by - 50; cy = cy - 50; dy = dy - 50; ey = ey - 50; fy = fy - 50;
                    ty = ty - 50;

                    if (i == NumBranches)
                    {
                        min = fy + 50;
                        Add(CreateLine(fx, min, fx, max));// соединяет все элементы 1
                        Add(CreateLine(fx + 90, min, fx + 90, max));
                        abcdX(20);
                    }
                }
                Add(CreateLine(Fx + 70, Fy, Ex + 70, Ey)); // линия 2

            }

            abcdX(70);
        }

        public Line CreateLine(double x1, double y1, double x2, double y2)
        {
            Line line = new Line();
            line.X1 = x1; line.Y1 = y1;
            line.X2 = x2; line.Y2 = y2;
            line.Stroke = Brushes.Black;
            return line;
        }
        private void CreateRectangle(int ax, int ay, int bx, int by, int cx, int cy, int dx, int dy, int fx, int fy, int ex, int ey, int x, int y)
        {
            Add(CreateLine(ax, ay, bx, by));
            Add(CreateLine(dx, dy, cx, cy));
            Add(CreateLine(ax, ay, dx, dy));
            Add(CreateLine(bx, by, cx, cy));
            Add(CreateLine(fx, fy, ex, ey)); // линия 1
            Add(CreateLine(fx + 70, fy, ex + 70, ey)); // линия 2
            TextBlock textBlock = new TextBlock();
            textBlock.Text = number.ToString();
            NumberElement();
            textBlock.Padding = new Thickness(x, y, 0, 0);
            Add(textBlock);

        }
        private void NumberElement()
        {
            number += 1;
            
        }
        public void Add(UIElement e)
        {
            UIelements.Add(e);
        }
        private void abcdY(int y)
        {
            Ay = Ay + y;
            By = By + y;
            Cy = Cy + y;
            Dy = Dy + y;
            tBlockY += y;
            Ey = Ey + y;
            Fy = Fy + y;
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
        public void ElementsToScheme()
        {
            UIelements.Clear();
            foreach(var item in Elements)
            {
                if (item.IsParallel == false)
                {
                    AddClick(true,item);
                }
                else
                {
                    AddClick(false,item);
                }
            }
        }
    }
}
