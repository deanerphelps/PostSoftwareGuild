using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IShape2D
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double Area()
        {
            return Math.PI * radius * radius;
        }

        public string Name()
        {
            return "Circle";
        }

        public double Perimeter()
        {
            return 2 * Math.PI * radius;
        }
    }
}
