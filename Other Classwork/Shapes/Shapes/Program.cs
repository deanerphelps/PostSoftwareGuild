using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            //IShape2D cirlce = new Circle(5);
            //Circle circle = new Circle();
            //IShape2D rectangle = new Rectangle(12, 5);
            //IShape2D triangle = new RightTriangle(10, 7);
            //Console.WriteLine(cirlce.Area());
            List<IShape2D> bagOfShapes = new List<IShape2D>();
            //Rectangle rect = new Rectangle(5, 3);
            //RightTriangle rTri = new RightTriangle(3, 4);
            // Circle circ = new Circle(82);
            //bagOfShapes.Add(rect);
            // bagOfShapes.Add(rTri);
            // bagOfShapes.Add(circ);
            // bagOfShapes.Add(cirlce);

            Random random = new Random();
            for (int i = 0; i < 100; ++i)
            {
                IShape2D shape;

                switch (random.Next(3))
                {
                    case 0:
                        shape = new Rectangle(random.NextDouble() * 100, random.NextDouble() * 100);
                        bagOfShapes.Add(shape);
                        break;
                    case 1:
                        shape = new RightTriangle(random.NextDouble() * 100, random.NextDouble() * 100);
                        bagOfShapes.Add(shape);
                        break;
                    case 2:
                        shape = new Circle(random.NextDouble() * 100);
                        bagOfShapes.Add(shape);
                        break;
                }
            }
            for (int i = 0; i < bagOfShapes.Count; ++i)
            {
                Console.WriteLine($"Shape #{i + 1} is a {bagOfShapes[i].Name()} has an area of \t{bagOfShapes[i].Area()}!");
            }
            ////////////////////////////////////////
            int count = 0;
            double totalArea = 0;
            for (int i = 0; i < bagOfShapes.Count; ++i)
            {
                if (bagOfShapes[i] is Circle)
                {
                    count++;
                    totalArea = totalArea + bagOfShapes[i].Area();
                }
            }
            Console.WriteLine($"\nThere are {count} circles, \n\twith area of {totalArea}");
            /////////////////////////////////////////
            count = 0;
            totalArea = 0;
            foreach(IShape2D shape in bagOfShapes)
            {
                if (shape is Circle)
                {
                    count++;
                    totalArea += shape.Area();
                }
            }
            Console.WriteLine($"\nThere are {count} circles, \n\twith area of {totalArea}");
            //////////////////////////////////////////
            IEnumerable<IShape2D> circles = bagOfShapes.Where(shape => shape is Circle);

            count = 0;
            totalArea = 0;
            foreach (Circle circleA in circles)
            {
                    count++;
                    totalArea += circleA.Area();
            }
            Console.WriteLine($"\nThere are {count} circles, \n\twith area of {totalArea}");
            /////////////////////////////////////
            IEnumerable<IShape2D> circles2 = bagOfShapes.Where(shape => shape is Circle);
            count = circles2.Count();
            totalArea = circles2.Sum(c => c.Area());
            
            Console.WriteLine($"\nThere are {count} circles, \n\twith area of {totalArea}");
            ////////////////////////////////////
            IEnumerable<IShape2D> circles3 = from IShape2D shape in bagOfShapes
                                             where shape is Circle
                                             select shape;
            count = circles3.Count();
            totalArea = circles3.Sum(c => c.Area());
            Console.WriteLine($"\nThere are {count} circles, \n\twith area of {totalArea}");
            //////////////////////////////////////
            var circles4 = from IShape2D shape in bagOfShapes
                                             where shape is Circle
                                             select
                                             new {
                                                 CirArea = shape.Area()
                                             };
            count = circles4.Count();
            totalArea = circles4.Sum(at => at.CirArea); //at stands for Anonymous Type. It can be ANYTHING
            Console.WriteLine($"\nThere are {count} circles, \n\twith area of {totalArea}");
            //////////////////////////////////////

            List<IShape2D> circles5 = circles3.ToList<IShape2D>();
            IShape2D[] circles6 = circles3.ToArray();

            Console.ReadLine();
        }
    }
}
