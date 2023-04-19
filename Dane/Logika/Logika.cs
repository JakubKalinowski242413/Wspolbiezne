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
        int _lenght;
        int _width;
        int _radius;

        List<Thread> _threads = new List<Thread>(); //Wątki do każdej ruchomej kulki

        ICommandBasen _basen = new Dane.Basen();

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
                _threads.Add(new Thread(new ParameterizedThreadStart(MoveBall)));
            }



            for (int i = 0; i < _basen.getBallCount(); i++)
            {
                _threads[i].Start(i);
            }

        }

        public void Deinitialize()
        {
            for (int i = 0; i < _basen.getBallCount(); i++)
            {
                _threads[i].Interrupt();
            }
            _threads.Clear();
            _basen.clean();
        }
        private void MoveBall(object n)
        {
            int i = (int)n;
            int x = _basen.getBall(i).XPosition;
            int y = _basen.getBall(i).YPosition;

            while (true)
            {
                x += (int)(_basen.getBall(i).SpeedValue * Math.Cos(_basen.getBall(i).SpeedAngle * Math.PI / 180.0));
                y -= (int)(_basen.getBall(i).SpeedValue * Math.Sin(_basen.getBall(i).SpeedAngle * Math.PI / 180.0));

                // TODO: wall collision detection
                if (x < _lenght - _radius && x > _radius && y < _width - _radius && y > _radius)
                {
                    _basen.getBall(i).XPosition = x;
                    _basen.getBall(i).YPosition = y;
                    Thread.Sleep(10);
                }
                else
                {
                    break;
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
            return (int)_threads.Count;
        }

    }
}
