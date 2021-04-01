using System;
using System.Collections.Generic;
using System.Text;

namespace task_2._2
{
    class StackCalculator
    {
        private bool IsDigit(char symbol)
        {
            int code = (int)symbol;
            int code0 = (int)'0';
            int code9 = (int)'9';

            if (code >= code0 && code <= code9)
            {
                return true;
            }

            return false;
        }

        private bool IsOperator(char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
        }

        private int CharToDigit(char symbol)
        {
            return (int)symbol - (int)'0';
        }
        public string Calculator()
        {
            char symbol = '\0';
            string number = "";
            NodeStack operands = new NodeStack();

            while (symbol != '\n')
            {
                if (symbol == ' ')
                {
                    if (number != "")
                    {
                        operands.PushBack(number);
                    }

                    number = "";
                }

                if (IsOperator(symbol))
                {
                    if (number != "")
                    {
                        operands.PushBack(number);
                    }
                    number = "";

                    int operand2 = Int32.Parse(operands.PopBack());
                    int operand1 = Int32.Parse(operands.PopBack());

                    switch (symbol)
                    {
                        case '+':
                            operands.PushBack((operand1 + operand2).ToString());
                            break;
                        case '-':
                            operands.PushBack((operand1 - operand2).ToString());
                            break;
                        case '*':
                            operands.PushBack((operand1 * operand2).ToString());
                            break;
                        case '/':
                            operands.PushBack((operand1 / operand2).ToString());
                            break;
                    }

                }

                if (IsDigit(symbol))
                {
                    number += symbol.ToString();
                }

                symbol = (char)Console.Read();
            }

            return operands.Peek();
        }
    }
}
