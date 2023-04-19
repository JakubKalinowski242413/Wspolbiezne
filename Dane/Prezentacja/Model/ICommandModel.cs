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
        int GetNumberOfBalls();
        ICommandPozycjaKul GetPozycjaKul(int i);
        int[] GetKolorKul(int i);
        void UpdatePozycjaKul();
    }
}
