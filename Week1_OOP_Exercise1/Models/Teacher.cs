using System.Collections.Generic;

namespace Week1_OOP_Exercise1.Models
{
    public class Teacher : People
    {
        public IEnumerable<Discipline> Disciplines { get; set; }
    }
}
