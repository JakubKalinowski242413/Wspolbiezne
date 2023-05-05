using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dane
{
    public class Kula : ICommandKula
    {
        double _XPosition;
        double _YPosition;
        int _Radius;
        double _XSpeed;
        double _YSpeed;
        int[] _BaseColor;
        int[] _CurrentColor;

        public double XPosition { get => _XPosition; set { lock(this) { _XPosition = value; } } }
        public double YPosition { get => _YPosition; set { lock (this) { _YPosition = value; } } }
        public int Radius { get => _Radius; set => _Radius = value; }
        public int Mass { get => _Radius * _Radius; }
        public double XSpeed { get => _XSpeed; set => _XSpeed = value; }
        public double YSpeed { get => _YSpeed; set => _YSpeed = value; }
        public int[] BaseColor { get => _BaseColor; set => _BaseColor = value; }
        public int[] CurrentColor { get => _CurrentColor; set => _CurrentColor = value; }

        public Kula(double xPosition, double yPosition, int radius, double xSpeed, double ySpeed, int[] baseColor)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Radius = radius;
            XSpeed = xSpeed;
            YSpeed = ySpeed;
            BaseColor = baseColor;
            CurrentColor = baseColor;
        }
    }
}
