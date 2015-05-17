using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lines
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected List<Point> Points = new List<Point>(24);

        protected void AddPoint(object sender, MouseButtonEventArgs e)
        {
            var point = Mouse.GetPosition(Canvas);

            Points.Add(point);

            Canvas.Children.Add(new Ellipse
            {
                Margin = new Thickness(point.X, point.Y, 0, 0),
                Stroke = Brushes.Wheat,
            });

            Draw(point);
        }

        protected void Clear(object sender, RoutedEventArgs e)
        {
            Points = new List<Point>(24);
            Canvas.Children.Clear();
        }

        private void Draw(Point outer)
        {
            foreach (var inner in Points)
            {
                Canvas.Children.Add(new Line
                {
                    Stroke = Brushes.White,
                    X1 = outer.X,
                    Y1 = outer.Y,
                    X2 = inner.X,
                    Y2 = inner.Y
                });
            }
        }
    }
}
