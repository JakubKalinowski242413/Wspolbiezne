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

        public void createBall(int XPosition, int YPosition, int Radius, int SpeedAngle, int SpeedValue, int[] Color)
        {
            if (XPosition > 0 && YPosition > 0 && Radius > 0 && 0 <= SpeedAngle && SpeedAngle < 360 && SpeedValue > 0)
            {
                kule.Add(new Kula(XPosition, YPosition, Radius, SpeedAngle, SpeedValue, Color));
            }
            else
            {
                throw new ArgumentOutOfRangeException("Błąd przy tworzeniu kuli. Ustaw poprawne X,Y oraz Promień");
            }
        }

        public void updateBall(int i, int XPosition, int YPosition)
        {
            kule[i].XPosition = XPosition;
            kule[i].YPosition = YPosition;
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

        void ICommandBasen.deleteBall(int i) { this.kule.RemoveAt(i);}

        void ICommandBasen.clean() { this.kule.Clear(); }
    }
}
