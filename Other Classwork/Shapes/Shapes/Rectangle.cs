using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IShape2D
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public double Area()
        {
            return length * width;
        }

        public string Name()
        {
            return "Rectangle";
        }

        public double Perimeter()
        {
            return (length * 2) + (width * 2);
        }
    }
}
