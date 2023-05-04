using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dane
{
    public class Kula : ICommandKula
    {
        int _XPosition;
        int _YPosition;
        int _Radius;
        int _XSpeed;
        int _YSpeed;
        int[] _BaseColor;
        int[] _CurrentColor;

        public int XPosition { get => _XPosition; set { lock(this) { _XPosition = value; } } }
        public int YPosition { get => _YPosition; set { lock (this) { _YPosition = value; } } }
        public int Radius { get => _Radius; set => _Radius = value; }
        public int Mass { get => _Radius * _Radius; }
        public int XSpeed { get => _XSpeed; set => _XSpeed = value; }
        public int YSpeed { get => _YSpeed; set => _YSpeed = value; }
        public int[] BaseColor { get => _BaseColor; set => _BaseColor = value; }
        public int[] CurrentColor { get => _CurrentColor; set => _CurrentColor = value; }

        public Kula(int xPosition, int yPosition, int radius, int xSpeed, int ySpeed, int[] baseColor)
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
