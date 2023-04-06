using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_8
{
    interface ICargoTransport
    {
        
        public double FullWeight { get; set; }
        public double UnladenWeight { get; set; }

        double LoadCapacity();
        int CompareTo(object obj);
        public object Clone();


    }
}
