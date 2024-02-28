using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Lab9_10CharpT
    {
        internal class FormulaEvaluatorArrayList
        {
            public static void Task3_1()
            {
                string formula = ReadFormulaFromFile("formula.txt");
                int result = EvaluateFormula(formula);

                Console.WriteLine($"Result: {result}");
            }

            static string ReadFormulaFromFile(string filePath)
            {
                try
                {
                    return File.ReadAllText(filePath).Trim();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                    return string.Empty;
                }
            }

            static int EvaluateFormula(string formula)
            {
                Stack<int> operandStack = new Stack<int>();
                Stack<char> operatorStack = new Stack<char>();
                int openingParenthesesCount = 0;
                int result = 0;

                for (int i = 0; i < formula.Length; i++)
                {
                    char currentChar = formula[i];
                    //Console.WriteLine($"current char: {currentChar}");

                    if (char.IsDigit(currentChar))
                    {
                        int digit = currentChar - '0';
                        operandStack.Push(digit);
                    }
                    else if (currentChar == 'M' || currentChar == 'm')
                    {
                        operatorStack.Push(currentChar);
                    }
                    else if (currentChar == '(')
                    {
                        openingParenthesesCount++;
                    }
                    else if (currentChar == ')')
                    {
                        openingParenthesesCount--;
                    }
                }

                if (openingParenthesesCount != 0)
                {
                    throw new InvalidOperationException(
                        "Invalid formula. Parentheses are not balanced."
                    );
                }

                while (operatorStack.Count > 0)
                {
                    result = PerformCalculations(operandStack, operatorStack);
                    operandStack.Push(result);
                }

                return result;
            }

            static int PerformCalculations(Stack<int> operandStack, Stack<char> operatorStack)
            {
                while (operatorStack.Count > 0)
                {
                    char currentOperator = operatorStack.Pop();
                    int operand1 = operandStack.Pop();
                    int operand2 = operandStack.Pop();
                    //Console.WriteLine(
                    //    $"current operator: {currentOperator}\n"
                    //        + $"operand1: {operand1} and operand2: {operand2}"
                    //);

                    if (currentOperator == 'M')
                    {
                        return Math.Max(operand1, operand2);
                    }
                    else if (currentOperator == 'm')
                    {
                        return Math.Min(operand1, operand2);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid operator.");
                    }
                }

                return 0;
            }
        }
    }

    class EmployeeArrayList
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

        public static void Task3_2()
        {
            string filePath = "employeeData.txt"; // Replace with the actual file path

            // Read employee data from the file
            List<Employee> employees = ReadEmployeeData(filePath);

            // Separate employees under 30 and others
            ArrayList under30List = new ArrayList();
            ArrayList otherList = new ArrayList();

            foreach (var employee in employees)
            {
                if (employee.Age < 30)
                {
                    under30List.Add(employee);
                }
                else
                {
                    otherList.Add(employee);
                }
            }

            // Print the elements in the required order
            Console.WriteLine("Employees under the age of 30:");
            PrintArrayList(under30List);
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Employees above the age of 30:");
            PrintArrayList(otherList);
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

        static void PrintArrayList(ArrayList list)
        {
            foreach (Employee employee in list)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
