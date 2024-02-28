using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    internal class FormulaEvaluator
    {
        public static void Task()
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
