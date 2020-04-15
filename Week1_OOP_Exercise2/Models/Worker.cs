using System;

namespace Week1_OOP_Exercise2.Models
{
    public class Worker : Human, IComparable<Worker>
    {
        public int WeekSalary { get; set; }
        public int WorkHour { get; set; }

        public Worker(string firstName = "", string lastName = "", int weekSalary = 0, int workHour = 0) : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            WorkHour = workHour;
        }

        public int MoneyPerHour
        {
            get
            {
                if (WorkHour == 0)
                {
                    return 0;
                }

                return (WeekSalary / WorkHour);
            }
        }

        public int CompareTo(Worker other)
        {
            if (other == null)
            {
                return 1;
            }

            return MoneyPerHour.CompareTo(other.MoneyPerHour);
        }
    }
}
