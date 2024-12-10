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
        /*/// <summary>
        /// среднее число отказов
        /// </summary>
       public double a;
        /// <summary>
        /// r отказов
        /// </summary>
        public double r;

        public double lambda;
        public double t;
        public double m;
        public static double Fact(double n)
        {
            if (n == 0)
                return 1;
            else
                return n * Fact(n - 1);
        }
        int Factorial(int n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }
        //public double Pp()
        //{
        //    //return (Math.Pow(a, r) / Factorial(r)) * Math.Exp(-a);
        //}
        public double P()
        {
            double ch = Math.Pow((lambda * t), m);
            double znam = Fact(m);
            return (ch/znam) * Math.Exp(-lambda*t);
        }
        */
        //lamb = 2.5 k= 0,1,2,3 ... 
        public double lambda; // Параметр распределения Пуассона (среднее количество событий за интервал времени)
        /// <summary>
        /// количество событий
        /// </summary>
        public int K;
        // Конструктор класса
        public PoissonLaw(double lambda)
        {
            if (lambda <= 0)
            {
                throw new ArgumentException("Параметр lambda должен быть положительным числом.");
            }
            this.lambda = lambda;
        }

        public PoissonLaw()
        {

        }

        // Метод для вычисления вероятности безотказной работы (P(k))
        public double P(int k)
        {
            if (k < 0)
            {
                throw new ArgumentException("Значение k должно быть неотрицательным.");
            }

            // Вычисление вероятности по формуле Пуассона
            double probability = (Math.Pow(lambda, k) * Math.Exp(-lambda)) / Factorial(k);
            return probability;
        }

        // Метод для вычисления факториала
        private static double Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    

    public StringBuilder Run(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Элемент №{id}");
            str.AppendLine($"lambda={lambda} ; k={K} ;");
            str.AppendLine($"Закон распределения - распределение Пуассона");
            str.AppendLine($"P = {P(K)}");
           
            str.AppendLine();
            return str;
        }

        public double P()
        {
            int k = K;
            if (k < 0)
            {
                throw new ArgumentException("Значение k должно быть неотрицательным.");
            }

            // Вычисление вероятности по формуле Пуассона
            double probability = (Math.Pow(lambda, k) * Math.Exp(-lambda)) / Factorial(k);
            return probability;
        }
    }
}
