using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public interface ICommandBasen
    {
        void createBall(int XPosition, int YPosition, int Radius, int SpeedAngle, int SpeedValue, int[] Color);
        void updateBall(int i, int XPosition, int YPosition);
        void deleteBall(int i);
        void clean();
        ICommandKula getBall(int i);
        int getBallCount();

    }
}
