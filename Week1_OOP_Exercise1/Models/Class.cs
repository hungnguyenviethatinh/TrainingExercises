using System.Collections.Generic;

namespace Week1_OOP_Exercise1.Models
{
    public class Class
    {
        public string Id { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
