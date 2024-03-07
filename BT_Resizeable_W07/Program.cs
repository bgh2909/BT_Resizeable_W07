using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Resizeable_W07
{
    internal class Program
    {
        public interface IResizeable
        {
            void Resize(double percent);
        }

        public class Circle : IResizeable
        {
            private double radius;

            public Circle(double radius)
            {
                this.radius = radius;
            }

            public void Resize(double percent)
            {
                radius *= (1 + percent / 100);
            }

            public double GetArea()
            {
                return Math.PI * radius * radius;
            }
        }

        public class Rectangle : IResizeable
        {
            private double width;
            private double length;

            public Rectangle(double width, double length)
            {
                this.width = width;
                this.length = length;
            }

            public void Resize(double percent)
            {
                width *= (1 + percent / 100);
                length *= (1 + percent / 100);
            }

            public double GetArea()
            {
                return width * length;
            }
        }

        // Class Square
        public class Square : Rectangle
        {
            public Square(double side) : base(side, side)
            {
            }
        }

        static double GetArea(IResizeable shape)
        {
            if (shape is Circle)
            {
                return ((Circle)shape).GetArea();
            }
            else if (shape is Rectangle)
            {
                return ((Rectangle)shape).GetArea();
            }
            else if (shape is Square)
            {
                return ((Square)shape).GetArea();
            }
            else
            {
                return 0; // Handle other shapes if needed
            }
        }

        static void Main(string[] args)
        {
            IResizeable[] shapes = new IResizeable[3];
            shapes[0] = new Circle(5);
            shapes[1] = new Rectangle(4, 6);
            shapes[2] = new Square(3);

            // Resize and display the shapes
            Random rand = new Random();
            foreach (var shape in shapes)
            {
                double resizePercent = rand.Next(1, 101);
                Console.WriteLine($"Area before resizing: {GetArea(shape)}");
                shape.Resize(resizePercent);
                Console.WriteLine($"Area after resizing by {resizePercent}%: {GetArea(shape)}");
                Console.WriteLine();

                Console.ReadKey();
            }
        }
    }
}
