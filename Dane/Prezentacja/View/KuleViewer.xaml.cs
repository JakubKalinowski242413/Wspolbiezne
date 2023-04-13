using Prezentacja.Model;
using Prezentacja.ViewModel;
using System.Windows;
using System.Windows.Threading;

namespace Prezentacja.View
{
    /// <summary>
    /// Logika interakcji dla klasy KuleViewer.xaml
    /// </summary>
    public partial class KuleViewer : Window
    {
        int speed = 1;
        DispatcherTimer timer = new DispatcherTimer();
        ICommandModel _model = new Model.Model();
       

        public KuleViewer()
        {
            InitializeComponent();
            DataContext = new ViewModeler();
            NumberBalls.Text = "Ilosc kul";
        }

    }
}
