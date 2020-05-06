namespace Week4_UnitTest_MemCalculator
{
    public class MemCalculator
    {
        int _sum;

        public MemCalculator()
        {
            _sum = 0;
        }

        public void Add(int number)
        {
            _sum += number;
        }

        public int Sum()
        {
            int sum = _sum;
            _sum = 0;

            return sum;
        }
    }
}
