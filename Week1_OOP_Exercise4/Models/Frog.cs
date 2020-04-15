using Week1_OOP_Exercise4.Core;

namespace Week1_OOP_Exercise4.Models
{
    public class Frog : Animal
    {
        public Frog(string name = "", float age = 0, Sex sex = Sex.Male) : base(name, age, sex)
        {
        }

        public override string GetSound()
        {
            return Constants.FrogSound;
        }
    }
}
