using Week_1_OOP_Exercise_3.Core;

namespace Week_1_OOP_Exercise_3.Models
{
    public class Circle : Shape
    {
        public Circle(float dimension = 0) : base(height: dimension, width: dimension)
        {
        }

        public override float CalculateSurface()
        {
            float dimesion = Height;
            float radius = dimesion / 2;

            return (radius * radius * Constants.Pi);
        }
    }
}
