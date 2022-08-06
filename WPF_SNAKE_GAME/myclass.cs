using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication1
{
    public class myclass
    {
        static int cnt= cnt + 1;
      
        public Rectangle newRectangle = new Rectangle
        {
            //properties set
            Width = 50,
            Height = 50,
            Name = "a"+cnt,
            
            StrokeThickness = 3,
            Stroke = Brushes.Black

        };

        //public Rectangle newRectangle1 = new Rectangle
        //{
        //    //properties set
        //    Width = 50,
        //    Height = 50,
        //    Name = "a" + cnt,

        //    StrokeThickness = 3,
        //    Stroke = Brushes.YellowGreen,
            
        //};

        //public myclass() {
        //    newRectangle1.SetValue(System.Windows.Controls.Canvas.TopProperty, System.Windows.Controls.Canvas.GetTop(newRectangle)+25.0);
        //    newRectangle1.SetValue(System.Windows.Controls.Canvas.LeftProperty, System.Windows.Controls.Canvas.GetLeft(newRectangle) + 25.0);
        //    }


        public int b;
        public int ID;


    };


}