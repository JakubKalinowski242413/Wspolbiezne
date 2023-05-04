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
                random.Next(5)+3, // XSpeed
                random.Next(5) + 3, // YSpeed
                new int[] { random.Next(255), random.Next(255), random.Next(255) });
                _tasks.Add(new Task(action: moveBall, i));
            }

            foreach(Task task in _tasks)
            {
                task.Start();
            }
        }

        public void Deinitialize()
        {
            // TODO: proper task cancelation
            foreach (Task task in _tasks)
            {
                task.Wait();
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
                x += _basen.getBall(iterator).XSpeed;
                y += _basen.getBall(iterator).YSpeed;

                _basen.getBall(iterator).XPosition = x;
                _basen.getBall(iterator).YPosition = y;
                Thread.Sleep(10);

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
            if (y < ja.Radius)
            {
                ja.YSpeed = Math.Abs(ja.YSpeed);
                ja.YPosition = ja.Radius;
            }
            if(y > width-ja.Radius)
            {
                ja.YSpeed = -Math.Abs(ja.YSpeed);
                ja.YPosition = width - ja.Radius;
            }
            
            //Left and Right wall
            if (x < ja.Radius)
            {
                ja.XSpeed = Math.Abs(ja.XSpeed);
                ja.XPosition = ja.Radius;
            }
            if (x > length - ja.Radius)
            {
                ja.XSpeed = -Math.Abs(ja.XSpeed);
                ja.XPosition = width - ja.Radius;
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
