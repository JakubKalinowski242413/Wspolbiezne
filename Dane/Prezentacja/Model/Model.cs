using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacja.Model
{
    internal class Model : ICommandModel
    {
        int _ballsNumber;
        List<ICommandPozycjaKul> pozycjeKul = new List<ICommandPozycjaKul>();
        ICommandLogika logika = new Logika.Logika();
        
        public void ModelInitialize(int length, int width, int ballsNumber, int radius = 10)
        {
            _ballsNumber = ballsNumber;
            logika.Initialize(length, width, ballsNumber, radius);

            for (int i = 0; i < _ballsNumber; i++)
            {
                pozycjeKul.Add(logika.GetPozycjaKul(i));
            }
        }

        public ICommandPozycjaKul GetPozycjaKul(int i)
        {
            return pozycjeKul[i];
        }

        public void UpdatePozycjaKul()
        {
            for (int i = 0; i < _ballsNumber; i++)
            {
                pozycjeKul[i] = logika.GetPozycjaKul(i);
            }
        }
        

    }
}
