using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    internal class PozycjaKul : ICommandPozycjaKul
    {
        int _XPosition;
        int _YPosition;

        public int XPosition { get => _XPosition; set => _XPosition = value; }
        public int YPosition { get => _YPosition; set => _YPosition = value; }
    }
}
