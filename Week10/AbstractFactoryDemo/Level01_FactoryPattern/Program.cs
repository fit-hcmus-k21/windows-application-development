using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level01_FactoryPattern
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    interface Shape
    {
        float Perimeter();
        float Area();
    }

    class Rectange : Shape
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public float Perimeter()
        {
            return (Width + Height) * 2;
        }

        public float Area()
        {
            return Width * Height;
        }
    }

    class Circle : Shape
    {
        public Point Center { get; set; }
        public float Radius { get; set; }

        const float PI = 3.14159265f;

        public float Area()
        {
            return PI * Radius * Radius;
        }

        public float Perimeter()
        {
            return PI * 2 * Radius;
        }
    }

    class ShapeFactory
    {
        public static Shape CreateShape(int type)
        {
            Shape result = null;

            switch (type)
            {
                case 1:
                    result = new Rectange() { Width = 5, Height = 7 };
                    break;
                case 2:
                    result = new Circle() { Radius = 10 };
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int RECTANGE = 1;
            const int CIRCLE = 2;

            Shape rect = ShapeFactory.CreateShape(RECTANGE);
            Shape circle = ShapeFactory.CreateShape(CIRCLE);

            Console.WriteLine("Shape 1. Perimeter:{0}, Area:{1}", 
                rect.Perimeter(), rect.Area());
            Console.WriteLine("Shape 2. Perimeter:{0:0.00}, Area:{1:0.00}",
                circle.Perimeter(), circle.Area());
        }
    }
}
