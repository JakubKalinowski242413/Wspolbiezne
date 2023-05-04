using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Logika : ICommandLogika
    {
        static int _lenght;
        static int _width;
        static int _radius;

        List<Task> _tasks = new List<Task>();
        static ICommandBasen _basen = new Dane.Basen();

        public void Initialize(int length, int width, int ballsNumber, int radius = 10)
        {
            _lenght = length;
            _width = width;
            _radius = radius;

            for (int i = 0; i < ballsNumber; i++)
            {
                Random random = new Random();
                _basen.createBall(random.Next(_lenght - 2 * _radius) + _radius, // X
                random.Next(_width - 2 * _radius) + _radius, // Y Gwarancja, że kulka znajdzie się w Canvas 
                _radius + random.Next(10), // R
                random.Next(360), // Dir
                3 + random.Next(7), // Vel
                new int[] { random.Next(255), random.Next(255), random.Next(255) });
                _tasks.Add(new Task(moveBall, i));
            }

            for (int i = 0; i < ballsNumber; i++)
            {
                _tasks[i].Start();
            }
        }

        public void Deinitialize()
        {
            for (int i = 0; i < _basen.getBallCount(); i++)
            {
                _tasks[i].Wait();
            }
            _tasks.Clear();
            _basen.clean();
        }

        Action<object> moveBall = (object i) =>
        {
            int iterator = (int)i;
            int x = _basen.getBall(iterator).XPosition;
            int y = _basen.getBall(iterator).YPosition;

            while (true)
            {
                checkWallCollision(iterator, _lenght, _width);
                x += (int)Math.Round(_basen.getBall(iterator).SpeedValue * Math.Cos(_basen.getBall(iterator).Angle * Math.PI / 180.0));
                y -= (int)Math.Round(_basen.getBall(iterator).SpeedValue * Math.Sin(_basen.getBall(iterator).Angle * Math.PI / 180.0));

                // TODO: wall collision detection
                if (x < _lenght - _radius && x > _radius && y < _width - _radius && y > _radius)
                {
                    _basen.getBall(iterator).XPosition = x;
                    _basen.getBall(iterator).YPosition = y;
                    Thread.Sleep(10);
                }
                   else
                {
                    break;
                }

            }
        };

        static int checkBallsCollision(int i)
        {
            ICommandKula ja = _basen.getBall(i);
            int x = ja.XPosition;
            int y = ja.YPosition;

            for (int j = 0; j < _basen.getBallCount(); j++)
            {
                if(i != j)
                {
                    int comparedX = _basen.getBall(j).XPosition;
                    int comparedY = _basen.getBall(j).YPosition;
                    int euclideanDistance = (int)Math.Round(Math.Sqrt((x - comparedX) * (x - comparedX) + (y - comparedY) * (y-comparedY)));
                    if (euclideanDistance <= ja.Radius + _basen.getBall(j).Radius)
                    {
                        return j;
                    }
                }
            }
            return -1;
        }

        static void checkWallCollision(int i, int length, int width)
        {
            ICommandKula ja = _basen.getBall(i);
            int x = ja.XPosition;
            int y = ja.YPosition;

            //Top and Bottom wall
            if (y < ja.Radius || y > width - ja.Radius)
            {
                ja.Angle = 360 - ja.Angle;
                if (y < ja.Radius)
                {
                    ja.YPosition = ja.Radius;
                }
                else
                {
                    ja.YPosition = width - ja.Radius;
                }
            }

            //Left and Right wall
            if (x < ja.Radius || x > length - ja.Radius)
            {
                if (ja.Angle <= 180)
                {
                    ja.Angle = 180 - ja.Angle;
                }
                else
                {
                    ja.Angle = 540 - ja.Angle;
                }
                if (x < ja.Radius)
                {
                    ja.XPosition = ja.Radius;
                }
                else
                {
                    ja.XPosition = length - ja.Radius;
                }
            }    
        }

        public ICommandPozycjaKul GetPozycjaKul(int i)
        {
            return new PozycjaKul { XPosition = _basen.getBall(i).XPosition, YPosition = _basen.getBall(i).YPosition };
        }

        public int[] GetKolorKul(int i){
            return _basen.getBall(i).CurrentColor;
        }

        public int GetNumberOfBalls()
        {
            return _basen.getBallCount();
        }

        public int GetNumberOfThreads()
        {
            return (int)_tasks.Count;
        }
    }
}
