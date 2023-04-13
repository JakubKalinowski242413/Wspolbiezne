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
        int _ballsNumber;
        int movePerTick = 2;

        List<int> _directions = new List<int>(); //Kierunek reprezentowany przez kąt <0,2pi>
        List<Thread> _threads = new List<Thread>(); //Wątki do każdej ruchomej kulki

        ICommandBasen _basen = new Dane.Basen(); 

        public void Initialize(int length, int width, int ballsNumber, int radius = 10)
        {
            _lenght = length;
            _width = width;
            _radius = radius;
            _ballsNumber = ballsNumber;

            Random random = new Random();
            for (int i = 0; i < _ballsNumber; i++)
            {
                _basen.createBall(random.Next(_lenght - 2 * _radius) + _radius,
                    random.Next(_width - 2 * _radius) + _radius, _radius); //Gwarancja, że kulka znajdzie się w Canvas
                _directions.Add(random.Next(360));
                _threads.Add(new Thread(new ParameterizedThreadStart(MoveBall)));
            }

            for (int i = 0; i < _ballsNumber; i++)
            {
                _threads[i].Start(i);
            }

        }

        private void MoveBall(object n)
        {
            int i = (int)n;
            int x = _basen.getBall(i).XAxis;
            int y = _basen.getBall(i).YAxis;

            while (true)
            {
                x += (int)Math.Round(movePerTick * Math.Cos(_directions[i] * Math.PI / 180.0));
                y -= (int)Math.Round(movePerTick * Math.Sin(_directions[i] * Math.PI / 180.0));

                if(x < _lenght - _radius && x > _radius && y < _width - _radius && y > _radius)
                {
                    _basen.getBall(i).XAxis = x;
                    _basen.getBall(i).YAxis = y;
                    Thread.Sleep(1);
                }
                else
                { 
                    break;
                }    

            }
        }

        public ICommandPozycjaKul GetPozycjaKul(int i)
        {
            return new PozycjaKul { XAxis = _basen.getBall(i).XAxis, YAxis = _basen.getBall(i).YAxis };
        }

        public int GetNumberOfDirections()
        {
            return _directions.Count;
        }

        public int GetNumberOfThreads()
        {
            return (int)_threads.Count;
        }

        public int GetMaxDirectionValue()
        {
            return _directions.Max();
        }
        public int GetMinDirectionValue()
        {
            return _directions.Min();
        }


    }
}
