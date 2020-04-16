namespace Week_1_OOP_Exercise_3.Models
{
    public class Rectangle : Shape
    {
        public Rectangle(float height = 0, float width = 0) : base(height, width)
        {
        }

        public override float CalculateSurface()
        {
            return (Height * Width);
        }
    }
}
