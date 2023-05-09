using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Prezentacja.Model
{
    internal class Model : ICommandModel
    {
        List<ICommandPozycjaKul> pozycjeKul = new List<ICommandPozycjaKul>();
        List<int[]> koloryKul = new List<int[]>();
        List<int> radii = new List<int>();
        ICommandLogika logika = new Logika.Logika();
        
        public void ModelInitialize(int length, int width, int ballsNumber, int radius = 10)
        {
            if (logika.GetNumberOfBalls() != 0)
            {
                logika.Deinitialize();
                
                pozycjeKul.Clear();
                pozycjeKul = new List<ICommandPozycjaKul>();
                koloryKul.Clear();
                koloryKul = new List<int[]>();
            }
            logika.Initialize(length, width, ballsNumber, radius);

            for (int i = 0; i < logika.GetNumberOfBalls(); i++)
            {
                pozycjeKul.Add(logika.GetPozycjaKul(i));
                koloryKul.Add(logika.GetKolorKul(i));
                radii.Add(logika.GetRadius(i));
            }
        }


        public int GetNumberOfBalls()
        {
            return logika.GetNumberOfBalls();
        }

        public ICommandPozycjaKul GetPozycjaKul(int i)
        {
            return pozycjeKul[i];
        }

        public int[] GetKolorKul(int i)
        {
            return koloryKul[i];
        }

        public int GetRadius(int i)
        {
            return radii[i];
        }

        public void UpdatePozycjaKul()
        {
            for (int i = 0; i < logika.GetNumberOfBalls(); i++)
            {
                pozycjeKul[i] = logika.GetPozycjaKul(i);
            }
        }
        

    }
}
