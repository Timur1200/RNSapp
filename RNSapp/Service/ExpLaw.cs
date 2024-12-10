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
        
        public double t;


        public double f()
        {
            return Lambda * Math.Exp(-Lambda * t);
        }
        public double P()
        {
            return Math.Exp(-Lambda * t);
        }
        public double T0()
        {
            return 1 / Lambda;
        }

        public StringBuilder Run(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Элемент №{id}");
            str.AppendLine($"Закон распределения - экспоненциальный");
            
            str.AppendLine($"P = {P()}");
            str.AppendLine($"lamb = {Lambda}");
            str.AppendLine($"t = {t}");
            str.AppendLine();
            return str;
        }
    }
}
