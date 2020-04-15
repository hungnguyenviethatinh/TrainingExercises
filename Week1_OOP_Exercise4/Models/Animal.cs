using Week1_OOP_Exercise4.Core;

namespace Week1_OOP_Exercise4.Models
{
    public class Animal
    {
        protected string _name;
        protected float _age;
        protected Sex _sex;
        protected string _sound;

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

        public Sex GetSex()
        {
            return _sex;
        }

        public virtual void SetSex(Sex sex)
        {
            _sex = sex;
        }

        public virtual string GetSound()
        {
            return _sound;
        }

        public Animal(string name = "", float age = 0, Sex sex = Sex.Male)
        {
            _name = name;
            _age = age;
            _sex = sex;
        }
    }
}
