using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNSapp.Service
{
    public class Elem
    {

        public Elem(int id)
        {
            Id = id;
        }
        public Elem(int id,int index)
        {
            Id = id;
            Index = index;
        }
        public int Id;
        public ILaw law;
        public double Q;
        
        public int Index;

        
        public override string ToString()
        {
            return $"{Id.ToString()}     _{Index}";
        }

        public bool IsReady()
        {
            if (law == null) return false;
            return true;
        }
        /// <summary>
        /// Вероятность безотказной работы || системы
        /// </summary>
        /// <returns></returns>
        public static double Psys(List<Elem> list)
        {
            double p = 1;
            foreach (Elem elem in list)
            {
                elem.Q = 1 - elem.law.P();
                p = p * elem.Q;
            }
            return p;
        }
        
    }
}
