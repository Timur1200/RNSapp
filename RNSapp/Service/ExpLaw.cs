using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNSapp.Service
{
    internal class ExpLaw : ILaw
    {

        public double Lambda;
        private double lambda
        {
            get
            {
                return Lambda * (10 ^ 6);
            }
        }
        public double t;


        public double f()
        {
            return lambda * Math.Exp(-lambda * t);
        }
        public double P()
        {
            return Math.Exp(-lambda * t);
        }
        public double T0()
        {
            return 1 / lambda;
        }

        public StringBuilder Run(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Элемент №{id}");
            str.AppendLine($"Закон распределения - экспоненциальный");
            str.AppendLine($"f = {f()}");
            str.AppendLine($"P = {P()}");
            str.AppendLine($"T0 = {T0()}");
            str.AppendLine();
            return str;
        }
    }
}
