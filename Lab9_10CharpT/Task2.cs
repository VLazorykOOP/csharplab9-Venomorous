using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    class Employee
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{Surname}, {Name}, {Patronymic}, {Gender}, {Age}, {Salary}";
        }

        public static void Task()
        {
            string filePath = "employeeData.txt"; // Replace with the actual file path

            // Read employee data from the file
            List<Employee> employees = ReadEmployeeData(filePath);

            // Separate employees under 30 and others
            Queue<Employee> under30Queue = new Queue<Employee>();
            Queue<Employee> otherQueue = new Queue<Employee>();

            foreach (var employee in employees)
            {
                if (employee.Age < 30)
                {
                    under30Queue.Enqueue(employee);
                }
                else
                {
                    otherQueue.Enqueue(employee);
                }
            }

            // Print the elements in the required order
            Console.WriteLine("Employees under the age of 30:");
            PrintQueue(under30Queue);
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Employees above the age of 30:");
            PrintQueue(otherQueue);
        }

        static List<Employee> ReadEmployeeData(string filePath)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 6)
                    {
                        Employee employee = new Employee
                        {
                            Surname = data[0].Trim(),
                            Name = data[1].Trim(),
                            Patronymic = data[2].Trim(),
                            Gender = data[3].Trim(),
                            Age = int.Parse(data[4].Trim()),
                            Salary = decimal.Parse(data[5].Trim())
                        };

                        employees.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }

            return employees;
        }

        static void PrintQueue(Queue<Employee> queue)
        {
            while (queue.Count > 0)
            {
                Employee employee = queue.Dequeue();
                Console.WriteLine(employee);
            }
        }
    }
}
