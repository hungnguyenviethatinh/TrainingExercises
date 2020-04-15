using System;
using Week_1_OOP_Exercise_3.Models;

namespace Week_1_OOP_Exercise_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Shape[] shapes = new Shape[3];
            shapes[0] = new Circle(7);
            shapes[1] = new Rectangle(1, 7);
            shapes[2] = new Triangle(1, 7);

            Console.WriteLine($"Shape one is a circle. Surface calculated: {shapes[0].CalculateSurface()}");
            Console.WriteLine($"Shape two is a rectangle. Surface calculated: {shapes[1].CalculateSurface()}");
            Console.WriteLine($"Shape three is a triangle. Surface calculated: {shapes[2].CalculateSurface()}");

            Console.ReadLine();
        }
    }
}
