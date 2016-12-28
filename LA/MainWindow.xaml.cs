using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Main m;

        public MainWindow()
        {
            InitializeComponent();
            m = new Main(this);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double x = 0;
            double y = 0;
            try
            {
                double.TryParse(tbX.Text, out x);
                double.TryParse(tbY.Text, out y);
                m.AddVector(x, y);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DrawVector(Models.Vector v)
        {
            Line line = new Line();
            Thickness thickness = new Thickness(101, -11, 362, 250);
            line.Margin = thickness;
            line.Visibility = System.Windows.Visibility.Visible;
            line.StrokeThickness = 4;
            line.Stroke = System.Windows.Media.Brushes.Black;
            double startcoord = 60;
            double lenght = v.GetVectorEnd();
            line.X1 = startcoord;
            line.X2 = Math.Sqrt(v.x * v.x + startcoord * startcoord);
            line.Y1 = startcoord;
            line.Y2 = Math.Sqrt(v.y * v.y + startcoord * startcoord);
            c.Children.Add(line);
            c.UpdateLayout();
        }
    }
}
