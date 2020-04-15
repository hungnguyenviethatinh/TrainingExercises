using System.Collections.Generic;

namespace Week1_OOP_Exercise1.Models
{
    public class School
    {
        public List<Class> Classes { get; set; }

        public School()
        {
            Classes = new List<Class>();
        }
    }
}
