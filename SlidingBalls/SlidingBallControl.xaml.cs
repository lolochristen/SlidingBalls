using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SlidingBalls
{
    /// <summary>
    /// Interaction logic for SlidingBallControl.xaml
    /// </summary>
    public partial class SlidingBallControl : UserControl
    {
        public Brush BallBrush
        {
            get { return (Brush)GetValue(BallBrushProperty); }
            set { SetValue(BallBrushProperty, value); }
        }

        public static readonly DependencyProperty BallBrushProperty =
           DependencyProperty.Register("BallBrush", typeof(Brush), typeof(SlidingBallControl), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0x7F, 0x2C, 0x93, 0xBA))));

        public Brush BallMouseOverBrush
        {
            get { return (Brush)GetValue(BallMouseOverBrushProperty); }
            set { SetValue(BallMouseOverBrushProperty, value); }
        }

        public static readonly DependencyProperty BallMouseOverBrushProperty =
           DependencyProperty.Register("BallMouseOverBrush", typeof(Brush), typeof(SlidingBallControl), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        public TimeSpan Delay
        {
            get { return (TimeSpan)GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        public static readonly DependencyProperty DelayProperty =
            DependencyProperty.Register("Delay", typeof(TimeSpan), typeof(SlidingBallControl), new PropertyMetadata(new TimeSpan(0)));


        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(SlidingBallControl), new PropertyMetadata(0d));

        public SlidingBallControl()
        {
            InitializeComponent();
        }

        private Brush _prevBrush;

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            _prevBrush = BallBrush;
            BallBrush = BallMouseOverBrush;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            BallBrush = _prevBrush;

        }
    }
}
