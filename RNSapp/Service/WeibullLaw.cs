using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace RNSapp.Service
{
    internal class WeibullLaw : ILaw
    {
        public double a;
        public double b;
        public double t;// время
        public double P()// функция надежности
        {
            double q1 = Math.Pow((t / a), b);
            return Math.Exp(-q1);
        }
        public double f() // функция плотности
        {
            double q1 = (b / a) * Math.Pow((t / a), b - 1);
            return q1 * P();
        }
        public double w()// интенсивность отказов
        {
            return f() / P();
        }

        public StringBuilder Run(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Элемент №{id}");
            str.AppendLine($"Закон распределения - закон Вейбулла");
            str.AppendLine($"f (функция плотности) = {f()}");
            str.AppendLine($"P (функция надежности) = {P()}");
            str.AppendLine($"w (интенсивность отказов) = {w()}");
            str.AppendLine();
            return str;
        }

    }
}
