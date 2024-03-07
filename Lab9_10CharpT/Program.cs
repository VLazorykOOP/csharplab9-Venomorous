using System;
using System.Collections.Generic;
using System.IO;
using Lab9_10CharpT;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Select a Task:");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Task 3_1");
            Console.WriteLine("4. Task 3_2");
            Console.WriteLine("5. Task 4");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------");

            switch (choice)
            {
                case "1":
                    FormulaEvaluator.Task();
                    break;

                case "2":
                    Employee.Task();
                    break;

                case "3":
                    FormulaEvaluatorArrayList formulaEvaluator = new FormulaEvaluatorArrayList();
                    formulaEvaluator.Task3_1();
                    break;

                case "4":
                    EmployeeArrayList.Task3_2();
                    break;

                case "5":
                    MusicCDCatalog.Task();
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
