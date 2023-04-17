using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Basen : ICommandBasen
    {
        List<ICommandKula> kule = new List<ICommandKula>();

        public void createBall(int XAxis, int YAxis, int Radius)
        {
            if (XAxis > 0 && YAxis > 0 && Radius > 0)
            {
                kule.Add(new Kula { XAxis = XAxis, YAxis = YAxis, Radius = Radius });
            }
            else
            {
                throw new ArgumentOutOfRangeException("Błąd przy tworzeniu kuli. Ustaw poprawne X,Y oraz Promień");
            }
        }

        public void updateBall(int i, int XAxis, int YAxis)
        {
            kule[i].XAxis = XAxis;
            kule[i].YAxis = YAxis;
        }

        public ICommandKula getBall(int i)
        {
            if (!(i > this.kule.Count))
            {
                return kule[i];
            }
            else 
            {
                throw new ArgumentNullException("Błąd przy pobieraniu kuli. Podana kula nie istnieje");
            }
        }

        int ICommandBasen.getBallCount()
        {
            return this.kule.Count;
        }

    }
}
