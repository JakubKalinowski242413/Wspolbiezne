using Kule.Dane;
using Kule.Logika;
using Kule.Prezentacja;

namespace Kule
{
    public partial class KuleWidok : Form
    {
        private Rysowanie rys = new Rysowanie(new BasenZKulkami());
        private ObijaczKulek obj = new ObijaczKulek(0, 0);
        public KuleWidok()
        {
            InitializeComponent();

            rys.wypelnijRysowanie();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint
                , true);



        }

        private void RysujKulki(object Sender, PaintEventArgs e)
        {

            rys.rysujKulki(Sender, e);
            obj.SzerokoscEkranu = this.ClientSize.Width;
            obj.WysokoscEkranu = this.ClientSize.Height;
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
        }



        private void AktualizujKulki(object sender, EventArgs e)
        {
            List<Kula> listaKulek = rys.dajBasen().wszystkieKulki();
            listaKulek.ForEach(k => { k.ResetKolor(); });
            obj.ruszWszystkieKule(listaKulek);
            this.Refresh();
        }
    }
}