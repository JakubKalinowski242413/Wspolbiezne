using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kule.Dane
{
    public class Kula
    {
        private float promien;
        private float pozycjaX;
        private float pozycjaY;
        private float predkoscX;
        private float predkoscY;
        private Brush kolorPodstawowy;
        private Brush kolor;


        public Kula(float promien, float pozycjaX, float pozycjaY, float predkoscX, float predkoscY, Brush kolor)
        {
            Promien = promien;
            PozycjaX = pozycjaX;
            PozycjaY = pozycjaY;
            PredkoscX = predkoscX;
            PredkoscY = predkoscY;
            KolorPodstawowy = kolor;
            Kolor = KolorPodstawowy;
        }

        public float Promien { get => promien; set => promien = value; }
        public float PozycjaX { get => pozycjaX; set => pozycjaX = value; }
        public float PozycjaY { get => pozycjaY; set => pozycjaY = value; }
        public float PredkoscX { get => predkoscX; set => predkoscX = value; }
        public float PredkoscY { get => predkoscY; set => predkoscY = value; }
        public Brush KolorPodstawowy { get => kolorPodstawowy; set => kolorPodstawowy = value; }
        public Brush Kolor { get => kolor; set => kolor = value; }
        public void ResetKolor() { this.Kolor = this.KolorPodstawowy; }
        public float Masa { get => promien * promien; }
        
    }
}
