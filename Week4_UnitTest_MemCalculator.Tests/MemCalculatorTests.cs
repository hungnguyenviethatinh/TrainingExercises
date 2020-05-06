using NUnit.Framework;

namespace Week4_UnitTest_MemCalculator.Tests
{
    [TestFixture]
    public class MemCalculatorTests
    {
        [Test]
        [Category("UnitTest_C2_MemCalculator")]
        public void Sum_ByDefault_ReturnZero()
        {
            MemCalculator memCalculator = MakeMemCalculator();

            int actual = memCalculator.Sum();

            Assert.AreEqual(0, actual);
        }

        [TestCase(-1, -1)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [Category("UnitTest_C2_MemCalculator")]
        public void Add_WhenCalled_ChangeSum(int number, int expected)
        {
            MemCalculator memCalculator = MakeMemCalculator();

            memCalculator.Add(number);
            int actual = memCalculator.Sum();

            Assert.AreEqual(expected, actual);
        }

        static MemCalculator MakeMemCalculator()
        {
            return new MemCalculator();
        }
    }
}
