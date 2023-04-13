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
        private string _ballsNumber;
        int speed = 1;
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
            int value = int.Parse(_ballsNumber);

            model.ModelInitialize((int)canvas.Width, (int)canvas.Height, value, radius); //Rozmiary Canvas sa domyslnie double
            for (int i = 0; i < value; i++)
            {
                Random random = new Random();
                Border ball = new Border();
                Brush color = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)random.Next(1, 255),
                  (byte)random.Next(1, 255), (byte)random.Next(1, 233)));

                ball.BorderBrush = Brushes.Black;
                ball.Height = 2 * radius;
                ball.Width = 2 * radius;
                ball.CornerRadius = new CornerRadius(50);
                ball.Background = color;
                canvas.Children.Add(ball);
                Canvas.SetLeft(ball, model.GetPozycjaKul(i).XAxis - radius);
                int x = model.GetPozycjaKul(i).XAxis; ;
                double q = (double)ball.GetValue(Canvas.LeftProperty);
                Canvas.SetTop(ball, model.GetPozycjaKul(i).YAxis - radius);
            }
            moveBall();
        }

        private void TimerEvent(object? sender, EventArgs e)
        {
            int value = int.Parse(_ballsNumber);
            model.UpdatePozycjaKul();
            for (int i = 0; i <value; i++)
            {
                int x = model.GetPozycjaKul(i).XAxis;
                int y = model.GetPozycjaKul(i).YAxis;
                Canvas.SetLeft(canvas.Children[i], x - radius);
                Canvas.SetRight(canvas.Children[i], y - radius);
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
            get { return _ballsNumber; }
            set
            {
                _ballsNumber = value;
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
