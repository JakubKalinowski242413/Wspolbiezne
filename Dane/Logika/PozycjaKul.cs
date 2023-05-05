using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    internal class PozycjaKul : ICommandPozycjaKul
    {
        double _XPosition;
        double _YPosition;

        public double XPosition { get => _XPosition; set => _XPosition = value; }
        public double YPosition { get => _YPosition; set => _YPosition = value; }
    }
}
