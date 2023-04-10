using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNSapp.Service
{
    internal class NormalLaw : ILaw
    {
        /// <summary>
        /// σ Сигма, Среднее квадратическое отклонение
        /// </summary>
        public double sigma;
        /// <summary>
        /// T0 Матем.ожидание
        /// </summary>
        public double T0;
        /// <summary>
        /// время
        /// </summary>
       public double t;
        /// <summary>
        /// Плотность нормального распределения
        /// </summary>
        double f()
        {
            double a = 1 / (sigma * Math.Sqrt(2*Math.PI));
            double b = (t - T0 * T0) / (2 * Math.Pow(sigma, 2));
            return a * Math.Exp(-b);
        }

        public StringBuilder Run(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Элемент №{id}");
            str.AppendLine($"Закон распределения - нормальный");
            str.AppendLine($"f = {f()}");
            str.AppendLine();
            return str;
        }
    }
}
