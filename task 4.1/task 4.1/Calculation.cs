using System;
using System.Collections.Generic;
using System.Text;

namespace task_4._1
{
    class Calculation
    {
        public int Calculate(string expression)
        {
            ParseTree tree = new ParseTree(expression);

            return tree.Calculate();
        }
    }
}
