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
            kule.Add(new Kula { XAxis = XAxis, YAxis = YAxis, Radius = Radius });
        }

        public void updateBall(int i, int XAxis, int YAxis)
        {
            kule[i].XAxis = XAxis;
            kule[i].YAxis = YAxis;
        }

        public ICommandKula getBall(int i)
        {
            return kule[i];
        }

        int ICommandBasen.getBallCount()
        {
            return this.kule.Count;
        }

    }
}
