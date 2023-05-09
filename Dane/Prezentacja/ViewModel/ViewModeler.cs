using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Prezentacja.Model;

namespace Prezentacja.ViewModel
{
    public class ViewModeler : INotifyPropertyChanged
    {
        private string ballNumberString = "3";
        int radius = 10;
        DispatcherTimer _timer = new DispatcherTimer();
        ICommandModel model = new Model.Model();
        Canvas canvas; //Canvas aka "pudełko" do którego będziemy ładować wszystkie kulki. 
        
        public ViewModeler()
        {
            ConfirmCommand = new RelayCommander(CreateBalls);
        }

        public ICommand ConfirmCommand { get; set; }

        public void CreateBalls(object o)
        {
            canvas = o as Canvas;
            canvas.Focus();
            int ballNumberFromString = int.Parse(ballNumberString);

            model.ModelInitialize((int)canvas.Width, (int)canvas.Height, ballNumberFromString, radius); //Rozmiary Canvas sa domyslnie double
            canvas.Children.Clear();
            for (int i = 0; i < model.GetNumberOfBalls(); i++)
            {
                Random random = new Random();
                Border ball = new Border();
                Brush color = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)model.GetKolorKul(i)[0],
                  (byte)model.GetKolorKul(i)[1], (byte)model.GetKolorKul(i)[2]));

                ball.BorderBrush = Brushes.Black;
                // TODO: add GetRadius to model
                ball.Height = 2 * model.GetRadius(i);
                ball.Width = 2 * model.GetRadius(i);
                ball.CornerRadius = new CornerRadius(50);
                ball.Background = color;
                canvas.Children.Add(ball);
                Canvas.SetLeft(ball, model.GetPozycjaKul(i).XPosition - radius);
                double x = model.GetPozycjaKul(i).XPosition;
                double q = (double)ball.GetValue(Canvas.LeftProperty);
                Canvas.SetTop(ball, model.GetPozycjaKul(i).YPosition - radius);
            }
            moveBall();
        }

        private void TimerEvent(object? sender, EventArgs e)
        {
            model.UpdatePozycjaKul();
            for (int i = 0; i <model.GetNumberOfBalls(); i++)
            {
                double x = model.GetPozycjaKul(i).XPosition;
                double y = model.GetPozycjaKul(i).YPosition;
                // TODO: add GetRadius to model
                Canvas.SetLeft(canvas.Children[i], x - radius);
                Canvas.SetTop(canvas.Children[i], y - radius);
            }
        }

        private void moveBall()
        {
            _timer.Tick += TimerEvent;
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Start();
        }

        public string BallsNumber
        {
            get { return ballNumberString; }
            set
            {
                ballNumberString = value;
                OnPropertyChanged(); //po zmianie w modelu zmienia sie dane w widoku
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
    }
}
