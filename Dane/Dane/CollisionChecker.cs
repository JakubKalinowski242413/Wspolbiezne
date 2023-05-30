using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class CollisionChecker : ILoggingSingle
    {
        DateTime _collisionTime;
        string _ballOne;
        string _ballTwo;

        public DateTime CollisionTime {
            get => _collisionTime; set => _collisionTime = value;
        }
        public string BallOne {
            get => _ballOne; set => _ballOne = value;
        }
        public string BallTwo {
            get => _ballTwo; set => _ballTwo = value;
        }

        public string collisionData {
            get => "Time of collision: "+CollisionTime.ToString() + '\n'+ "\nFirst ball:\n" + BallOne + '\n' + "\nSecond ball:\n"
                + BallTwo + "\n\n";
        }
    }
}
