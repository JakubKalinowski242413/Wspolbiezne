using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    internal class PozycjaKul : ICommandPozycjaKul
    {
        int _XAxis;
        int _YAxis;

        public int XAxis { get => _XAxis; set => _XAxis = value; }
        public int YAxis { get => _YAxis; set => _YAxis = value; }
    }
}
