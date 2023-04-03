using Kule.Dane;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Kule.Prezentacja
{
    internal class Rysowanie
    {
        private BasenZKulkami basenZKulkami;
        private Random random = new Random();
        private IDictionary<String, Brush> brushes = new Dictionary<String, Brush>()
        {
            {"pink", Brushes.Pink},
            {"blue", Brushes.Blue},
            {"violet", Brushes.Violet},
            {"green", Brushes.Green},
            {"yellow", Brushes.Yellow},
        };
        
        /*private Brush[] brushes = new Brush[]
        {
            Brushes.Pink, Brushes.Blue, Brushes.Violet, Brushes.Green, Brushes.Yellow, Brushes.Red
        };*/

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
            for(int i = 0; i < 6; i++)
            {
                Kula kula = new Kula((random.Next() % 20) + 20,
                    100*i + random.Next() % 20,
                    200 + random.Next() % 20, 
                    random.Next()%5 + 5, 
                    random.Next() % 5 + 5, 
                    brushes.ElementAt(random.Next(0, brushes.Count)).Value);
                basenZKulkami.wrzucKulke(kula);
            }
        }

        public void rysujKulki(object Sender, PaintEventArgs e)
        {
            List < Kula > listaKul = basenZKulkami.wszystkieKulki();
            listaKul.ForEach(kula =>
            {
                e.Graphics.FillEllipse(kula.Kolor, kula.PozycjaX-kula.Promien, kula.PozycjaY - kula.Promien, 2*kula.Promien, 2*kula.Promien);
            });
        }
    }
}
