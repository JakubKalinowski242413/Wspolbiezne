using Prezentacja.Model;
using Prezentacja.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Text.RegularExpressions;

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
       
    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    public KuleViewer()
        {
            InitializeComponent();
            DataContext = new ViewModeler();
            NumberBalls.Text = "3";
        }

    }
}
