using System;

namespace Week1_OOP_Exercise2.Models
{
    public class Student : Human, IComparable<Student>
    {
        public int Grade { get; set; }

        public Student(string firstName = "", string lastName = "", int grade = 0) : base(firstName, lastName)
        {
            Grade = grade;
        }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                return 1;
            }

            return Grade.CompareTo(other.Grade);
        }
    }
}
