using System;

namespace task_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "(-(+54)5)";

            Calculation test1 = new Calculation();
            Console.WriteLine(test1.Calculate(expression));
        }
    }
}
