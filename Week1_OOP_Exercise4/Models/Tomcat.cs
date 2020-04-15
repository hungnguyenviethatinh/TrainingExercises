using Week1_OOP_Exercise4.Core;

namespace Week1_OOP_Exercise4.Models
{
    public sealed class Tomcat : Cat
    {
        public Tomcat(string name = "", float age = 0) : base(name, age)
        {
            _sex = Sex.Male;
        }

        public override void SetSex(Sex sex)
        {
            _sex = Sex.Male;
        }
    }
}
