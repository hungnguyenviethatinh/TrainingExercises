using System.Collections.Generic;

namespace Week1_OOP_Exercise1.Models
{
    public class Class
    {
        public string Id { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }

        public Class(string id = "")
        {
            Id = id;
            Teachers = new List<Teacher>();
            Students = new List<Student>();
        }
    }
}
