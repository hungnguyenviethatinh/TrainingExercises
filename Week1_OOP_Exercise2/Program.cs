using System;
using Week1_OOP_Exercise2.Models;
using Week1_OOP_Exercise2.Utils;

namespace Week1_OOP_Exercise2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Student[] students = new Student[10];
            Worker[] workers = new Worker[10];

            Console.WriteLine("Generated list of students below:");
            for (int i = 0; i < 10; i++)
            {
                string firstName = Randomize.GenerateString();
                string lastName = Randomize.GenerateString();
                int grade = Randomize.GenerateNumber();

                students[i] = new Student(firstName, lastName, grade);

                Console.WriteLine($"{i + 1} - Grade: {grade}, Name: {firstName}, Last name: {lastName}.");
            }

            Console.WriteLine("Generated list of workers below:");
            for (int i = 0; i < 10; i++)
            {
                string firstName = Randomize.GenerateString();
                string lastName = Randomize.GenerateString();
                int weekSalary = Randomize.GenerateNumber(1000000, 5000000);
                int workHour = Randomize.GenerateNumber(0, 40);

                workers[i] = new Worker(firstName, lastName, weekSalary, workHour);

                Console.WriteLine($"{i + 1} - Money per hour: {workers[i].MoneyPerHour}, Name: {firstName}, Last name: {lastName}, Week salary: {weekSalary}, Work hour(s): {workHour}.");
            }

            Array.Sort(students);
            Array.Sort(workers);

            Console.WriteLine("Asc sorted list of students by grade below:");
            foreach (var student in students)
            {
                Console.WriteLine($"Grade: {student.Grade}, Name: {student.FirstName}, Last name: {student.LastName}.");
            }

            Console.WriteLine("Desc sorted list of works by money per hour below:");
            foreach (var worker in workers)
            {
                Console.WriteLine($"Money per hour: {worker.MoneyPerHour}, Name: {worker.FirstName}, Last name: {worker.LastName}, Week salary: {worker.WeekSalary}, Work hour(s): {worker.WorkHour}.");
            }

            Console.ReadLine();
        }
    }
}
