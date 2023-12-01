
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using MyLib;

namespace RentangleLib
{
    public class RectangleShape : IShape
    {
        public override UIElement Draw()
        {
            // TODO: can dam bao Diem 0 < Diem 1
            double width = Points[1].X - Points[0].X;
            double height = Points[1].Y - Points[0].Y;

            var element = new System.Windows.Shapes.Rectangle()
            {
                Width = width,
                Height = height,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Canvas.SetLeft(element, Points[0].X);
            Canvas.SetTop(element, Points[0].Y);

            return element;
        }

        public override IShape Clone()
        {
            return new RectangleShape();
        }

        public override string Name => "Rectangle";
    }

}
