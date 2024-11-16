using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNSapp.Service
{
    public interface ILaw
    {
        StringBuilder Run(int id);
        double P();
    }
}
