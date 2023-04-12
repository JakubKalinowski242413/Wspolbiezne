using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dane
{
    public class Kula : ICommandKula
    {
        int _XAxis;
        int _YAxis;
        int _Radius;

        public int XAxis { get => _XAxis; set { lock(this) { _XAxis = value; } } }
        public int YAxis { get => _YAxis; set { lock (this) { _YAxis = value; } } }
        public int Radius { get => _Radius; set => _Radius = value; }


    }
}
