using Dane;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Logika : ICommandLogika
    {
        static int _lenght;
        static int _width;
        static int _radius;
        static List<bool> isLocked = new List<bool>();
        static bool stopProgram = false;

        List<int> radii = new List<int>();
        List<Task> _tasks = new List<Task>();
        static ICommandBasen _basen = new Dane.Basen();

        public void Initialize(int length, int width, int ballsNumber, int radius = 10)
        {
            _lenght = length;
            _width = width;
            _radius = radius;
            stopProgram = false;

            for (int i = 0; i < ballsNumber; i++)
            {
                Random random = new Random();
                radii.Add(_radius + random.Next(10));
                _basen.createBall(random.Next(_lenght - 2 * _radius) + _radius, // X
                random.Next(_width - 2 * _radius) + _radius, // Y Gwarancja, że kulka znajdzie się w Canvas 
                radii[i], // R
                random.Next(2) + 3, // XSpeed
                random.Next(2) + 3, // YSpeed
                new int[] { random.Next(255), random.Next(255), random.Next(255) });
                isLocked.Add(false);
                _tasks.Add(new Task(moveBall, i));
            }

            foreach(Task task in _tasks)
            {
                task.Start();
            }
        }

        public void Deinitialize()
        {
            stopProgram = true;
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
            double x = _basen.getBall(iterator).XPosition;
            double y = _basen.getBall(iterator).YPosition;

            while (!stopProgram)
            {   
                if (isLocked[iterator])
                {
                    continue;
                }
                int collisionIterator = checkBallsCollision(iterator);

                if (collisionIterator != -1)
                {
                    lock (isLocked)
                    {
                        isLocked[collisionIterator] = true;
                    }    

                    double collisionX = _basen.getBall(collisionIterator).XPosition;
                    double collisionY = _basen.getBall(collisionIterator).YPosition;
                    double collisionAngle = Math.Atan2(collisionY - y, collisionX - x);

                    // Mass of the balls
                    int m1 = _basen.getBall(iterator).Mass;
                    int m2 = _basen.getBall(collisionIterator).Mass;

                    // Speeds before collision
                    double vx1 = _basen.getBall(iterator).XSpeed;
                    double vy1 = _basen.getBall(iterator).YSpeed;
                    double vx2 = _basen.getBall(collisionIterator).XSpeed;
                    double vy2 = _basen.getBall(collisionIterator).YSpeed;

                    // Speed after collision
                    double vx1_new = (((m1 - m2) * vx1 + 2 * m2 * vx2) * Math.Cos(collisionAngle) / (m1 + m2) + vy1 * Math.Sin(collisionAngle));
                    double vy1_new = (((m1 - m2) * vy1 + 2 * m2 * vy2) * Math.Cos(collisionAngle) / (m1 + m2) - vx1 * Math.Sin(collisionAngle));
                    double vx2_new = (((m2 - m1) * vx2 + 2 * m1 * vx1) * Math.Cos(collisionAngle) / (m1 + m2) + vy2 * Math.Sin(collisionAngle));
                    double vy2_new = (((m2 - m1) * vy2 + 2 * m1 * vy1) * Math.Cos(collisionAngle) / (m1 + m2) - vx2 * Math.Sin(collisionAngle));

                    //Set values of speed
                    _basen.getBall(iterator).XSpeed = vx1_new;
                    _basen.getBall(iterator).YSpeed = vy1_new;
                    _basen.getBall(collisionIterator).XSpeed = vx2_new;
                    _basen.getBall(collisionIterator).YSpeed = vy2_new;

                    //Set positions after collision

                }
                checkWallCollision(iterator, _lenght, _width);

                x += _basen.getBall(iterator).XSpeed;
                y += _basen.getBall(iterator).YSpeed;
                _basen.getBall(iterator).XPosition = x;
                _basen.getBall(iterator).YPosition = y;

                if (collisionIterator != -1)
                {
                    lock (isLocked)
                    {
                        isLocked[collisionIterator] = false;
                    }    
                }
                Thread.Sleep(10);
            }
        };
    
        static int checkBallsCollision(int i)
        {
            ICommandKula ja = _basen.getBall(i);
            double x = ja.XPosition;
            double y = ja.YPosition;

            for (int j = 0; j < _basen.getBallCount(); j++)
            {
                if(i != j)
                {
                    double comparedX = _basen.getBall(j).XPosition;
                    double comparedY = _basen.getBall(j).YPosition;
                    double euclideanDistance = Math.Sqrt((x - comparedX) * (x - comparedX) + (y - comparedY) * (y-comparedY));
                    if (euclideanDistance < ja.Radius + _basen.getBall(j).Radius)
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
            double x = ja.XPosition;
            double y = ja.YPosition;
            int radius = ja.Radius;

            //Top and Bottom wall          
            if (y < radius)
            {
                ja.YSpeed = Math.Abs(ja.YSpeed);
                ja.YPosition = radius;
            }
            if(y > width-radius)
            {
                ja.YSpeed = -Math.Abs(ja.YSpeed);
                ja.YPosition = width - radius;
            }
            
            //Left and Right wall
            if (x < radius)
            {
                ja.XSpeed = Math.Abs(ja.XSpeed);
                ja.XPosition = radius;
            }
            if (x > length - radius)
            {
                ja.XSpeed = -Math.Abs(ja.XSpeed);
                ja.XPosition = width - radius;
            }    
        }

        public ICommandPozycjaKul GetPozycjaKul(int i)
        {
            return new PozycjaKul { XPosition = _basen.getBall(i).XPosition, YPosition = _basen.getBall(i).YPosition };
        }
        
        public int[] GetKolorKul(int i)
        {
            return _basen.getBall(i).CurrentColor;
        }

        public int GetRadius(int i)
        {
            return radii[i];
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
