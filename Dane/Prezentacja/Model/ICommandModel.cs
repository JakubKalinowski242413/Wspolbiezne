using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja.Model
{
    internal interface ICommandModel
    {
        void ModelInitialize(int length, int width, int ballsNumber, int radius);
        ICommandPozycjaKul GetPozycjaKul(int i);
        void UpdatePozycjaKul();
    }
}
