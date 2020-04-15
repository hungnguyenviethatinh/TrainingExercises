using Week1_OOP_Exercise4.Core;

namespace Week1_OOP_Exercise4.Models
{
    public class Cat : Animal
    {
        public Cat(string name = "", float age = 0, Sex sex = Sex.Male) : base(name, age, sex)
        {
        }

        public override string GetSound()
        {
            return Constants.CatSound;
        }
    }
}
