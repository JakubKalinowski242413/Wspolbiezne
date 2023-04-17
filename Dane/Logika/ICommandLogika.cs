using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public interface ICommandLogika
    {
        void Initialize(int length, int width, int ballsNumber, int radius = 10);
        ICommandPozycjaKul GetPozycjaKul(int i);
        int GetNumberOfThreads();
        int GetNumberOfDirections();
    }
}
