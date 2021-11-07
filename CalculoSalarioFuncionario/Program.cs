using CalculoSalarioFuncionario.Entities.Enums;
using System.Globalization;
using System;
using CalculoSalarioFuncionario.Entities;

namespace CalculoSalarioFuncionario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter departament's name:");
            string departament = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            string l = Console.ReadLine();
            WorkerLevel level = System.Enum.Parse<WorkerLevel>(l);
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Departament dept = new Departament(departament);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker?");
            int contractNumbers = int.Parse(Console.ReadLine());

            for(int i = 1; i<=contractNumbers; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Data:");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour:");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours):");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);

            }
            Console.Write("Enter month and year to calculate  income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            double income = worker.Income(year, month);

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departament: " + worker.Departament.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + income.ToString("F2",CultureInfo.InvariantCulture));

        }
    }
}
