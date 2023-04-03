using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kule.Dane
{
    internal class BasenZKulkami
    {
        private List<Kula> kule;

        public BasenZKulkami()
        {
            this.kule = new List<Kula>();
        }

        public void wrzucKulke(Kula kula)
        {
            this.kule.Add(kula);
        }

        public void wyjmijKulke(Kula kula)
        {
            this.kule.Remove(kula);
        }

        public int policzKulki()
        {
            return this.kule.Count;
        }

        public Kula zlapKulke(int index)
        {
            return this.kule[index];
        }

        public List<Kula> wszystkieKulki()
        {
            return this.kule;
        }
    }
}
