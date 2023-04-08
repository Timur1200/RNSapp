using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNSapp.Service
{
    internal class NormalLaw
    {
        /// <summary>
        /// σ Сигма, Среднее квадратическое отклонение
        /// </summary>
        double sigma;
        /// <summary>
        /// T0 Матем.ожидание
        /// </summary>
        double T0;
        /// <summary>
        /// время
        /// </summary>
        double t;
        /// <summary>
        /// Плотность нормального распределения
        /// </summary>
        double f()
        {
            double a = 1 / (sigma * Math.Sqrt(2*Math.PI));
            double b = (t - T0 * T0) / (2 * Math.Pow(sigma, 2));
            return a * Math.Exp(-b);
        }
    }
}
