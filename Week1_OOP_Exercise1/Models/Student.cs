namespace Week1_OOP_Exercise1.Models
{
    public class Student : People
    {
        public string ClassId { get; set; }

        public Student(string name = "", string classId = "") : base(name)
        {
            ClassId = classId;
        }
    }
}
