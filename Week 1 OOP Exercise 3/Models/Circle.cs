using Week_1_OOP_Exercise_3.Core;

namespace Week_1_OOP_Exercise_3.Models
{
    public class Circle : Shape
    {
        public float Radius { get; set; }

        public Circle(float radius = 0) : base(height: 2 * radius, width: 2 * radius)
        {
            Radius = radius;
        }

        public override float CalculateSurface()
        {
            return (Radius * Radius * Constants.Pi);
        }
    }
}
