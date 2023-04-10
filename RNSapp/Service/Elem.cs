using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNSapp.Service
{
    public  class Elem
    {
        public Elem(int id) 
        {
            Id = id;
        }
        public int Id;
        public ILaw law;

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool IsReady()
        {
            if (law == null) return false;
            return true;
        }
    }
}
