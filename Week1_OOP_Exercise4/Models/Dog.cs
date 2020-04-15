using Week1_OOP_Exercise4.Core;

namespace Week1_OOP_Exercise4.Models
{
    public class Dog : Animal
    {
        public Dog(string name = "", float age = 0, Sex sex = Sex.Male) : base(name, age, sex)
        {
        }

        public override string GetSound()
        {
            return Constants.DogSound;
        }
    }
}
