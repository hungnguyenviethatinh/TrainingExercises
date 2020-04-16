using Week1_OOP_Exercise4.Core;

namespace Week1_OOP_Exercise4.Models
{
    public abstract class Animal
    {
        protected string _name;
        protected float _age;
        protected Sex _sex;

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public float GetAge()
        {
            return _age;
        }

        public void SetAge(float age)
        {
            _age = age;
        }

        public Sex GetSex()
        {
            return _sex;
        }

        public virtual void SetSex(Sex sex)
        {
            _sex = sex;
        }

        public abstract string GetSound();

        protected Animal(string name = "", float age = 0, Sex sex = Sex.Male)
        {
            _name = name;
            _age = age;
            _sex = sex;
        }

        public static AnimalType Identify(Animal animal)
        {
            string sound = animal.GetSound();

            switch (sound)
            {
                case Constants.CatSound:
                    return AnimalType.Cat;
                case Constants.DogSound:
                    return AnimalType.Dog;
                case Constants.FrogSound:
                    return AnimalType.Frog;
                default:
                    return AnimalType.Undefined;
            }
        }
    }
}
