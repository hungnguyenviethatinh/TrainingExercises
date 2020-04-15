namespace Week1_OOP_Exercise1.Models
{
    public class Discipline
    {
        public string Name { get; set; }
        public int NumberOfLectures { get; set; }
        public int NumberOfExercises { get; set; }

        public Discipline(string name = "", int numberOfLectures = 0, int numberOfExercises = 0)
        {
            Name = name;
            NumberOfLectures = numberOfLectures;
            NumberOfExercises = numberOfExercises;
        }
    }
}
