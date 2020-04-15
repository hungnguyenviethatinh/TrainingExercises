using System.Collections.Generic;

namespace Week1_OOP_Exercise1.Models
{
    public class Teacher : People
    {
        public List<Discipline> Disciplines { get; set; }

        public Teacher(string name = "") : base(name)
        {
            Disciplines = new List<Discipline>();
        }
    }
}
