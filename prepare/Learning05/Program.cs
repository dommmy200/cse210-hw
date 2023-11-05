using System;

namespace ShapeAndColors {
    class Program {
        static void Main(string[] args) {
            Square square = new Square(4.5d, "Blue");
            double squ = square.GetArea();
            string squCol = square.GetColor();
            Rectangle rectangle = new Rectangle(3.6d, 2.0d, "Yellow");
            double rec = rectangle.GetArea();
            string recCol = rectangle.GetColor();
            Circle circle = new Circle(8.4d, "Green");
            double cir = circle.GetArea();
            string cirCol = circle.GetColor();

            List<Shape> shapes = new List<Shape>(5) {
                square, rectangle, circle
            };
            foreach (Shape shape in shapes){
                string col = shape.GetColor();
                double dou = shape.GetArea();
                Console.WriteLine($"{shape} = '{col}' {dou}");
            }

            Console.WriteLine($"Area of Square: {squ} and Color: {squCol}\nArea of Rectangle: {rec} and Color: {recCol}\nArea of Square: {cir} and Color: {cirCol}");
        }
    }
}