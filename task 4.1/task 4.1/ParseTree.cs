using System;
using System.Collections.Generic;
using System.Text;

namespace task_4._1
{
    class ParseTree
    {
        private Node root;

        public int Calculate()
        {
            return root.Value;
        }

        private Queue<string> ParseExpression(string expression)
        {
            var queue = new Queue<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                queue.Enqueue(expression[i].ToString());
            }

            return queue;
        }

        public ParseTree(string expression)
        {
            var queue = ParseExpression(expression);

            root = CreateSubtree(queue);
        }

        private Node CreateSubtree(Queue<string> queue)
        {
            Node subTree;

            if (queue.Peek() == "(")
            {
                queue.Dequeue();

                switch (queue.Dequeue())
                {
                    case "+":
                        subTree = new Summ();
                        break;
                    case "-":
                        subTree = new Subtraction();
                        break;
                    case "*":
                        subTree = new Multiplication();
                        break;
                    case "/":
                        subTree = new Division();
                        break;
                    default:
                        throw new FormatException("Incorrect expression\n");
                }

                if (subTree is Operator operation)
                {
                    operation.LeftOperand = CreateSubtree(queue);
                    operation.RightOperand = CreateSubtree(queue);
                }

                queue.Dequeue();
            }
            else
            {
                subTree = new Operand(int.Parse(queue.Dequeue()));
            }

            return subTree;
        }
    }
}
