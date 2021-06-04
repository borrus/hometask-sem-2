using System;
using System.Collections.Generic;
using System.Text;

namespace task_4._1
{
    public class Operand : Node
    {
        public Operand(int value)
        {
            Value = value;
        }

        public override int Value
        {
            get;
        }
    }
}
