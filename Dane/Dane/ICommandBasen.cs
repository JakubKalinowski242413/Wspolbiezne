using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public interface ICommandBasen
    {
        void createBall(int XAxis, int YAxis, int Radius);
        void updateBall(int i, int XAxis, int YAxis);
        ICommandKula getBall(int i);
        int getBallCount();

    }
}
