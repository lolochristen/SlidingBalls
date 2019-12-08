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

namespace SlidingBalls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateBalls();
        }

        private void CreateBalls()
        {
            Container.Children.Clear();
            int max = int.Parse(NumberBalls.Text); //36; // (int) (360 / 3);
            double delay = double.Parse(Delay.Text);
            double fillAngle = double.Parse(FillAngle.Text);
            for (int i = 1; i <= max; i++)
            {
                var c = FromHSL(1d / max * (i - 1), 0.5, 0.5);
                c.A = 200;

                Container.Children.Add(new SlidingBallControl()
                {
                    Delay = new TimeSpan(0, 0, 0, 0, (int)(delay / max * i)),
                    Angle = fillAngle / max * i,
                    BallBrush = new SolidColorBrush(c)
                }); // (byte)(255/max*i)
            }
        }

        // Given H,S,L in range of 0-1
        // Returns a Color (RGB struct) in range of 0-255
        public static Color FromHSL(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);

            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;

                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }
            return Color.FromRgb(Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateBalls();
            }
            catch
            {
            }
        }
    }
}
