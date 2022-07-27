using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {

        Point currentPoint = new Point();
        Rectangle newRectangle = new Rectangle
        {
            //properties set
            Width = 50,
            Height = 50,

            StrokeThickness = 3,
            Stroke = Brushes.Black
        };
        //   Rectangle newRectangle;

        public MainWindow()
        {
            string b = "9";
            InitializeComponent();
            //customcolor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));
         
            newRectangle.Name = "myrect";
            //position of mouse click area
            System.Windows.Controls.Canvas.SetLeft(newRectangle, 50);
            System.Windows.Controls.Canvas.SetTop(newRectangle, 100);
            //canvas add
            paintSurface.Children.Add(newRectangle);
    


        }

        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);

         

        }

        private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();

                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                currentPoint = e.GetPosition(this);

            
               



            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string b = "123";
            b = paintSurface.Children.Count.ToString();
            Console.WriteLine(b);
            text22.Text = b;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //  System.Windows.Controls.Canvas.SetLeft(newRectangle,  50.0);
            button_1.SetValue(System.Windows.Controls.Canvas.LeftProperty, button_1.Width + 1);
            button_1.SetValue(System.Windows.Controls.Canvas.TopProperty, button_1.Width + 1);
            newRectangle.Width = newRectangle.Width + 1;
            newRectangle.Height = newRectangle.Height + 1;
            newRectangle.SetValue(System.Windows.Controls.Canvas.LeftProperty, System.Windows.Controls.Canvas.GetLeft(newRectangle) + 20);
            newRectangle.SetValue(System.Windows.Controls.Canvas.TopProperty, System.Windows.Controls.Canvas.GetTop(newRectangle) + 20);
            if (System.Windows.Controls.Canvas.GetLeft(newRectangle) > 300) {
                newRectangle.SetValue(System.Windows.Controls.Canvas.LeftProperty, System.Windows.Controls.Canvas.GetLeft(newRectangle) - 200);
                newRectangle.SetValue(System.Windows.Controls.Canvas.TopProperty, System.Windows.Controls.Canvas.GetTop(newRectangle) - 200);
            }
        }
    }
}