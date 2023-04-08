using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNSapp.Service
{
    internal class ExpLaw : ILaw
    {

        double lambda;
        double t;
        

        public double f()
        {
            return lambda * Math.Exp(-lambda*t);
        }
        public double P()
        {
            return Math.Exp(-lambda*t);
        }
        public double T0()
        {
            return 1 / lambda;
        }
    }
}
