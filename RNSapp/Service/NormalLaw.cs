using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNSapp.Service
{
    using System;
    using System.Text;

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
            double a = 1 / (sigma * Math.Sqrt(2 * Math.PI));
            double b = (t - T0) * (t - T0) / (2 * Math.Pow(sigma, 2));
            return a * Math.Exp(-b);
        }

        /// <summary>
        /// Вероятность безотказной работы
        /// </summary>
       public double P()
        {
            double z = (t - T0) / (sigma * Math.Sqrt(2));
            return 0.5 * (1 + Erf(z));
        }

        /// <summary>
        /// Приближенная функция ошибок (erf)
        /// </summary>
        double Erf(double x)
        {
            // Приближенная формула для функции ошибок
            const double a1 = 0.254829592;
            const double a2 = -0.284496736;
            const double a3 = 1.421413741;
            const double a4 = -1.453152027;
            const double a5 = 1.061405429;
            const double p = 0.3275911;

            double sign = Math.Sign(x);
            x = Math.Abs(x);

            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return sign * y;
        }

        public StringBuilder Run(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Элемент №{id}");
            str.AppendLine($"Закон распределения - нормальный");
            str.AppendLine($"f = {f()}");
            str.AppendLine($"P(t) = {P()}");
            str.AppendLine();
            return str;
        }

        
    }
}
