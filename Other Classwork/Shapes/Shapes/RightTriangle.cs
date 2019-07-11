using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class RightTriangle : IShape2D
    {
        private double length;
        private double width;

        public RightTriangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public double Area()
        {
            return length * width / 2;
        }

        public string Name()
        {
            return "Triangle";
        }

        public double Perimeter()
        {
            return length + width + Math.Sqrt(length * length + width * width);
        }
    }
}
