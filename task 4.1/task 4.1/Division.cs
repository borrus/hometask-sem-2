using System;
using System.Collections.Generic;
using System.Text;

namespace task_4._1
{
    public class Division : Operator
    {
        public override int Value => LeftOperand.Value / RightOperand.Value;

        public override char Operation
        {
            get
            {
                return '/';
            }
        }
    }
}
