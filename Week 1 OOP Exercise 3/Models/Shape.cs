namespace Week_1_OOP_Exercise_3.Models
{
    public abstract class Shape
    {
        public float Height { get; set; }
        public float Width { get; set; }

        protected Shape(float height = 0, float width = 0)
        {
            Height = height;
            Width = width;
        }

        public virtual float CalculateSurface()
        {
            return 0;
        }
    }
}
