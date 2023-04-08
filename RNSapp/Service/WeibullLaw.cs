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
        double a;
        double b;
        double t;
        public double P()
        {
            double q1 = Math.Pow((t / a), b);
            return Math.Exp(-q1);
        }
        public double f()
        {
            double q1 = (b / a) * Math.Pow((t / a), b - 1);
            return q1 * P();
        }
        public double w()
        {
            return f() / P();
        }

        

    }
}
