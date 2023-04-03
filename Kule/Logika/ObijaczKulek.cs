using Kule.Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kule.Logika
{
    internal class ObijaczKulek
    {

        private int szerokoscEkranu;
        private int wysokoscEkranu;

        public int SzerokoscEkranu { get => szerokoscEkranu; set => szerokoscEkranu = value; }
        public int WysokoscEkranu { get => wysokoscEkranu; set => wysokoscEkranu = value; }

        public ObijaczKulek(int szerokoscEkranu, int wysokoscEkranu)
        {
            this.szerokoscEkranu = szerokoscEkranu;
            this.wysokoscEkranu = wysokoscEkranu;
        }

        private void ruszKulke(Kula kula, List<Kula> kule)
        {
            // Ball on ball action detection (works)
            for(int i =0; i < kule.Count; i++)
            {
                if  (
                    (kula.PozycjaX - kule[i].PozycjaX)* (kula.PozycjaX - kule[i].PozycjaX) +
                    (kula.PozycjaY - kule[i].PozycjaY) * (kula.PozycjaY - kule[i].PozycjaY) <=
                    (kula.Promien + kule[i].Promien) * (kula.Promien + kule[i].Promien)
                    &&
                    !kula.Equals(kule[i])
                    )
                {
                    // Balls touched
                    zderzenieKulek(kula, kule[i]);
                    break;
                }
            }

            // This works
            // Wall colision detection
            if (kula.PozycjaX - kula.Promien <= 0)
            {
                kula.PredkoscX = Math.Abs(kula.PredkoscX);
                kula.PozycjaX = kula.Promien;
            }
            if (kula.PozycjaX + kula.Promien >= szerokoscEkranu)
            {
                kula.PredkoscX = -Math.Abs(kula.PredkoscX);
                kula.PozycjaX = szerokoscEkranu - kula.Promien;
            }
            if (kula.PozycjaY - kula.Promien <= 0)
            {
                kula.PredkoscY = Math.Abs(kula.PredkoscY);
                kula.PozycjaY = kula.Promien;
            }
            if (kula.PozycjaY + kula.Promien >= wysokoscEkranu)
            {
                kula.PredkoscY = -Math.Abs(kula.PredkoscY);
                kula.PozycjaY = wysokoscEkranu - kula.Promien;
            }

            // Apply speed
            kula.PozycjaX += kula.PredkoscX;
            kula.PozycjaY += kula.PredkoscY;
        }

        private void zderzenieKulek(Kula kula1, Kula kula2)
        {
            // TODO: fix (balls can oscilate now, that's bad for your health)
            // We could use momentum equation for speed calculation (mass and speed)
            kula1.PredkoscX = -kula1.PredkoscX;
            kula2.PredkoscX = -kula2.PredkoscX;
            kula1.PredkoscY = -kula1.PredkoscY;
            kula2.PredkoscY = -kula2.PredkoscY;
            kula1.Kolor = Brushes.Red;
            kula2.Kolor = Brushes.Red;
        }
        public void ruszWszystkieKule(List<Kula> kule)
        {
            kule.ForEach(k => { ruszKulke(k, kule); });
        }
    }
}
