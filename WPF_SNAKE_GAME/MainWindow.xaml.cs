using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication1

{
    public partial class MainWindow : Window
    {
          



        Point currentPoint = new Point();
        public  string direction = "9";
        List<double> x_arr = new List<double>();
        List<double> y_arr = new List<double>();
        List<int> x_arr_duplicat = new List<int>();
        List<int> y_arr_duplicat = new List<int>();
        int cnt_rectangle;


        public MainWindow()
        {
          
            InitializeComponent();
            CreateObj();
            DispatcherTimer time = new DispatcherTimer();

            time.Interval = TimeSpan.FromMilliseconds(500);
            time.Tick += timer_Tick;
            time.Start();
            cnt_rectangle = paintSurface.Children.OfType<Rectangle>().Count() - 1;


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
            CreateObj();

         }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int cnt_rectangle = paintSurface.Children.OfType<Rectangle>().Count() - 1;

            if  (cnt_rectangle >= 1)
                {
                paintSurface.Children.Remove(paintSurface.Children.OfType<Rectangle>().ElementAt(cnt_rectangle));

            }

       



        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                e.Handled = true;
               // up();
                direction = "up";
                
            }

            if (e.Key == Key.Down)
            {
                e.Handled = true;
             //   down();
                direction = "down";

            }

            if (e.Key == Key.Right)
            {
                e.Handled = true;
              //  right();
                direction = "right";

            }

            if (e.Key == Key.Left)
            {
                e.Handled = true;
              // left();
               direction = "left";



            }

        }
        public void timer_Tick(object sender, EventArgs e)
        {
           findCollision();

            if (cnt_rectangle >= 0)
            {
                if (direction == "right")
                {
                    right();
                }
                if (direction == "left")
                {
                    left();
                }

                if (direction == "up")
                {
                    up();
                }

                if (direction == "down")
                {
                    down();
                }
            }
            else
                direction = "stop";



        }
        public void up() 
        {
           x_arr.Clear();
           y_arr.Clear();

        
            for (int i = 0; i < paintSurface.Children.OfType<Rectangle>().Count() - 1; i++)
            {
                findCollision();
                x_arr.Add(System.Windows.Controls.Canvas.GetLeft(paintSurface.Children.OfType<Rectangle>().ElementAt(i)));
                    y_arr.Add(System.Windows.Controls.Canvas.GetTop(paintSurface.Children.OfType<Rectangle>().ElementAt(i)));

            }

            double xx = System.Windows.Controls.Canvas.GetTop(paintSurface.Children.OfType<Rectangle>().ElementAt(0));
            paintSurface.Children.OfType<Rectangle>().ElementAt(0).SetValue(System.Windows.Controls.Canvas.TopProperty, xx - 50.0);

            for (int i = 1; i < paintSurface.Children.OfType<Rectangle>().Count(); i++)
            {
                findCollision();
               if ( direction != "stop"){
                    paintSurface.Children.OfType<Rectangle>().ElementAt(i).SetValue(System.Windows.Controls.Canvas.LeftProperty, x_arr[i - 1]);
                    paintSurface.Children.OfType<Rectangle>().ElementAt(i).SetValue(System.Windows.Controls.Canvas.TopProperty, y_arr[i - 1]);
                }
                               
            }
           




        }
        public void down() {
            x_arr.Clear();
            y_arr.Clear();
            //--------------------------------
         
            

            for (int i = 0; i < paintSurface.Children.OfType<Rectangle>().Count() - 1; i++)
            {
                findCollision();
                x_arr.Add(System.Windows.Controls.Canvas.GetLeft(paintSurface.Children.OfType<Rectangle>().ElementAt(i)));
                y_arr.Add(System.Windows.Controls.Canvas.GetTop(paintSurface.Children.OfType<Rectangle>().ElementAt(i)));

            }

            double xx = System.Windows.Controls.Canvas.GetTop(paintSurface.Children.OfType<Rectangle>().ElementAt(0));

            paintSurface.Children.OfType<Rectangle>().ElementAt(0).SetValue(System.Windows.Controls.Canvas.TopProperty, xx + 50.0);


            for (int i = 1; i < paintSurface.Children.OfType<Rectangle>().Count(); i++)
            {
                findCollision();
                if (direction != "stop")
                {


                    paintSurface.Children.OfType<Rectangle>().ElementAt(i).SetValue(System.Windows.Controls.Canvas.LeftProperty, x_arr[i - 1]);
                    paintSurface.Children.OfType<Rectangle>().ElementAt(i).SetValue(System.Windows.Controls.Canvas.TopProperty, y_arr[i - 1]);
                
                if (i % 2 == 0)
                {
                    paintSurface.Children.OfType<Rectangle>().ElementAt(i).Fill = new SolidColorBrush(Colors.Green);
                }

                else
                {
                    paintSurface.Children.OfType<Rectangle>().ElementAt(i).Fill = new SolidColorBrush(Colors.Olive);
                }

                }
            }


            //paintSurface.Children[5].SetValue(System.Windows.Controls.Canvas.TopProperty, System.Windows.Controls.Canvas.GetTop(paintSurface.Children[5]) + newRectangle.Height);







        }
        public void right() 
        {

            x_arr.Clear();
            y_arr.Clear();

                if (direction != "stop")
            { 
                                 
                    for (int i = 0; i < paintSurface.Children.OfType<Rectangle>().Count() - 1; i++)
                      {
                        x_arr.Add(System.Windows.Controls.Canvas.GetLeft(paintSurface.Children.OfType<Rectangle>().ElementAt(i)));
                        y_arr.Add(System.Windows.Controls.Canvas.GetTop(paintSurface.Children.OfType<Rectangle>().ElementAt(i)));

                       }

                     double xx = System.Windows.Controls.Canvas.GetLeft(paintSurface.Children.OfType<Rectangle>().ElementAt(0));
                     paintSurface.Children.OfType<Rectangle>().ElementAt(0).SetValue(System.Windows.Controls.Canvas.LeftProperty, xx + 50.0);


                   for (int i = 1; i < paintSurface.Children.OfType<Rectangle>().Count(); i++)
                        {
                        paintSurface.Children.OfType<Rectangle>().ElementAt(i).SetValue(System.Windows.Controls.Canvas.LeftProperty, x_arr[i - 1]);
                        paintSurface.Children.OfType<Rectangle>().ElementAt(i).SetValue(System.Windows.Controls.Canvas.TopProperty, y_arr[i - 1]);
                        if (i % 2 == 0)
                            {
                               paintSurface.Children.OfType<Rectangle>().ElementAt(i).Fill = new SolidColorBrush(Colors.Green);
                            }
    
                        else
                             {
                               paintSurface.Children.OfType<Rectangle>().ElementAt(i).Fill = new SolidColorBrush(Colors.Olive);
                             }

                         }
            }



        }
        public void left() {

            x_arr.Clear();
            y_arr.Clear();
         


            for (int i = 0; i < paintSurface.Children.OfType<Rectangle>().Count() - 1; i++)
            {
                x_arr.Add(System.Windows.Controls.Canvas.GetLeft(paintSurface.Children.OfType<Rectangle>().ElementAt(i)));
                y_arr.Add(System.Windows.Controls.Canvas.GetTop(paintSurface.Children.OfType<Rectangle>().ElementAt(i)));

            }

            double xx = System.Windows.Controls.Canvas.GetLeft(paintSurface.Children.OfType<Rectangle>().ElementAt(0));

            paintSurface.Children.OfType<Rectangle>().ElementAt(0).SetValue(System.Windows.Controls.Canvas.LeftProperty, xx - 50.0);


            for (int i = 1; i < paintSurface.Children.OfType<Rectangle>().Count(); i++)
            {
                paintSurface.Children.OfType<Rectangle>().ElementAt(i).SetValue(System.Windows.Controls.Canvas.LeftProperty, x_arr[i - 1]);
                paintSurface.Children.OfType<Rectangle>().ElementAt(i).SetValue(System.Windows.Controls.Canvas.TopProperty, y_arr[i - 1]);
                if (i % 2 == 0)
                {
                    paintSurface.Children.OfType<Rectangle>().ElementAt(i).Fill = new SolidColorBrush(Colors.Green);
                }

                else
                {
                    paintSurface.Children.OfType<Rectangle>().ElementAt(i).Fill = new SolidColorBrush(Colors.Olive);
                }


            }



            //paintSurface.Children[5].SetValue(System.Windows.Controls.Canvas.LeftProperty, System.Windows.Controls.Canvas.GetLeft(paintSurface.Children[5]) - newRectangle.Width);




        }
        public void CreateObj() {
            myclass mycla = new myclass();
            mycla.b = paintSurface.Children.Count;
            mycla.ID = paintSurface.Children.Count;
            mycla.newRectangle.Fill = new SolidColorBrush(Colors.OrangeRed);
            mycla.newRectangle.Name = "rectangle_" + paintSurface.Children.Count;
            System.Windows.Controls.Canvas.SetLeft(mycla.newRectangle, 200.0);
            System.Windows.Controls.Canvas.SetTop(mycla.newRectangle, 200.0);
            //canvas add
            paintSurface.Children.Add(mycla.newRectangle);
           // paintSurface.Children.Add(mycla.newRectangle1);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int count = paintSurface.Children.Count;
            text22.Text = count.ToString();
            direction = "right";
            paintSurface.Children.OfType<Rectangle>().ElementAt(0).SetValue(System.Windows.Controls.Canvas.LeftProperty, 1300.0);
            paintSurface.Children.OfType<Rectangle>().ElementAt(0).SetValue(System.Windows.Controls.Canvas.TopProperty, 300.0);

            double x = System.Windows.Controls.Canvas.GetLeft(paintSurface.Children.OfType<Rectangle>().ElementAt(0));
            double y = System.Windows.Controls.Canvas.GetTop(paintSurface.Children.OfType<Rectangle>().ElementAt(0));


            for (int i = 1; i < paintSurface.Children.OfType<Rectangle>().Count(); i++)
            {
                paintSurface.Children.OfType<Rectangle>().ElementAt(i).SetValue(System.Windows.Controls.Canvas.LeftProperty, x-(50.0* Convert.ToDouble(i)));
                paintSurface.Children.OfType<Rectangle>().ElementAt(i).SetValue(System.Windows.Controls.Canvas.TopProperty, y);

            }
            paintSurface.Background = new SolidColorBrush(Colors.White);


        }

        public void findCollision() {

            #region Linq comment
            //bool hasDuplicates_x_arr = x_arr.GroupBy(x => x).Any(g => g.Count() > 1);
            //bool hasDuplicates_y_arr = y_arr.GroupBy(x => x).Any(g => g.Count() > 1);



            //var query = x_arr.Select((value, index) => new { value, index })
            //      .Where(x => x.value >300)
            //      .Select(x => x.index)
            //      .Take(5);



            //           // Trace.WriteLine(query.Count());
            //);


            //var duplicated_y = y_arr.Select((x, i) => new { i, x })
            //       .GroupBy(x => x.x)
            //       .Where(g => g.Count() > 1)
            //       .ToDictionary(g => g.Key, g => g.Select(x => x.i).ToList());



            //List<double> duplicated_yy = duplicated_y.Keys.ToList();


            //for (int i = 0; i < duplicated_y.Count(); i++)
            //{
            //    for (int j = 0; j < y_arr.Count(); j++)
            //    {
            //        if (duplicated_yy.ElementAt(i) == y_arr.ElementAt(j))
            //        {
            //            Trace.WriteLine(j);
            //        }


            //    }
            //};

            //Trace.WriteLine("Duplicate elements are: " + String.Join(",", duplicates));

            #endregion


            int cnt_rectangle = paintSurface.Children.OfType<Rectangle>().Count() - 1;

            for (int j = 1; j < y_arr.Count(); j++)
            {
                if (     (y_arr.ElementAt(0) == y_arr.ElementAt(j)- 0 ) & (x_arr.ElementAt(0) == x_arr.ElementAt(j)) & cnt_rectangle>0 & direction=="up")
                {
                    direction = "stop";
                    Trace.WriteLine(j);
                    Trace.WriteLine("-------------");
                    paintSurface.Background = new SolidColorBrush(Colors.Red);

                }

                if ((y_arr.ElementAt(0) == y_arr.ElementAt(j)+ 0) & (x_arr.ElementAt(0) == x_arr.ElementAt(j)) & cnt_rectangle > 0 & direction == "down" )
                {
                    direction = "stop";
                    Trace.WriteLine(j);
                    Trace.WriteLine("-------------");
                    paintSurface.Background= new SolidColorBrush(Colors.Red);

                }
                if ((y_arr.ElementAt(0) == y_arr.ElementAt(j)) & (x_arr.ElementAt(0) == x_arr.ElementAt(j)-0) & cnt_rectangle > 0 & direction == "left")
                {
                    direction = "stop";
                    Trace.WriteLine(j);
                    Trace.WriteLine("-------------");
                    paintSurface.Background = new SolidColorBrush(Colors.Red);

                }
                if ((y_arr.ElementAt(0) == y_arr.ElementAt(j)) & (x_arr.ElementAt(0) == x_arr.ElementAt(j)+0) & cnt_rectangle > 0 & direction == "right")
                {
                    direction = "stop";
                    Trace.WriteLine(j);
                    Trace.WriteLine("-------------");
                    paintSurface.Background = new SolidColorBrush(Colors.Red);

                }
            }



              
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            findCollision();
            direction = "right";

        }
    }
    }
