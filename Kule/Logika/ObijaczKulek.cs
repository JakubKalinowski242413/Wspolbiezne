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
        private void ruszKulke(Kula kula)
        {

        }

        public void ruszWszystkieKule(List<Kula> kule)
        {
            kule.ForEach(ruszKulke);
        }
    }
}
