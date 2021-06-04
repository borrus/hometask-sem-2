using System;
using System.Collections.Generic;
using System.Text;

namespace task_4._1
{
    public abstract class Operator : Node
    {
        public Node LeftOperand
        {
            get;
            set;
        }

        public Node RightOperand
        {
            get;
            set;
        }

        public abstract char Operation
        {
            get;
        }
    }
}
