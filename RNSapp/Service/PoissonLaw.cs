using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNSapp.Service
{
    /// <summary>
    /// Распределение Пуассона
    /// </summary>
    internal class PoissonLaw : ILaw
    {
        /// <summary>
        /// среднее число отказов
        /// </summary>
       public double a;
        /// <summary>
        /// r отказов
        /// </summary>
       public double r;
        double Factorial(double n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }
       public double P()
        {

            return (Math.Pow(a, r) / Factorial(r)) * Math.Exp(-a);
        }

        public StringBuilder Run(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Элемент №{id}");
            str.AppendLine($"Закон распределения - распределение Пуассона");
            str.AppendLine($"P = {P()}");
           
            str.AppendLine();
            return str;
        }
    }
}
