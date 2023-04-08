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
        double a;
        /// <summary>
        /// r отказов
        /// </summary>
        double r;
        double Factorial(double n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }
        double P()
        {

            return (Math.Pow(a, r) / Factorial(r)) * Math.Exp(-a);
        }
    }
}
