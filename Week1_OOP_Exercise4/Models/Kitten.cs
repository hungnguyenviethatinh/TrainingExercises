using Week1_OOP_Exercise4.Core;

namespace Week1_OOP_Exercise4.Models
{
    public sealed class Kitten : Cat
    {
        public Kitten(string name = "", float age = 0) : base(name, age)
        {
            _sex = Sex.Female;
        }

        public override void SetSex(Sex sex)
        {
            _sex = Sex.Female;
        }
    }
}
