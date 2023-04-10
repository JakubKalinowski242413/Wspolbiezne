using Kule.Dane;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Kule.Prezentacja.ViewModel
{
    internal class Rysowanie
    {
        private BasenZKulkami basenZKulkami;
        private Random random = new Random();
        private IDictionary<string, Brush> brushes = new Dictionary<string, Brush>()
        {
            {"pink", Brushes.Pink},
            {"blue", Brushes.Blue},
            {"violet", Brushes.Violet},
            {"green", Brushes.Green},
            {"yellow", Brushes.Yellow},
            {"grey", Brushes.Gray},
            {"brown", Brushes.Brown}
        };

        public Rysowanie(BasenZKulkami basenZKulkami)
        {

            this.basenZKulkami = basenZKulkami;
        }

        public BasenZKulkami dajBasen()
        {
            return basenZKulkami;
        }

        public void wypelnijRysowanie()
        {
            for (int i = 0; i < 6; i++)
            {
                int wspolczynnikMasyKulki = random.Next(10, 40);
                int wspolczynnikKierunkuKulki = random.Next(5, 501);
                Kula kula = new Kula(wspolczynnikMasyKulki,
                    100 * (i + 1) + random.Next(0, 21),
                    200 + random.Next(0, 21),
                    wspolczynnikKierunkuKulki / wspolczynnikMasyKulki,
                    (501 - wspolczynnikKierunkuKulki) / wspolczynnikMasyKulki,
                    brushes.ElementAt(random.Next(0, brushes.Count)).Value);
                basenZKulkami.wrzucKulke(kula);
            }
        }

        public void rysujKulki(object Sender, PaintEventArgs e)
        {
            List<Kula> listaKul = basenZKulkami.wszystkieKulki();
            listaKul.ForEach(kula =>
            {
                e.Graphics.FillEllipse(kula.Kolor, kula.PozycjaX - kula.Promien, kula.PozycjaY - kula.Promien, 2 * kula.Promien, 2 * kula.Promien);
            });
        }
    }
}
