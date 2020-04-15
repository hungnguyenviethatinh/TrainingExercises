namespace Week1_OOP_Exercise2.Models
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Human(string firstName = "", string lastName = "")
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
