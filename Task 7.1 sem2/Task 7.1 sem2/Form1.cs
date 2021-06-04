using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_7._1_sem2
{
    public partial class Form1 : Form
    {
        enum CalcStates
        {
            waitingForFirstOperand,
            waitingForOperator,
            waitingForSecondOperand,
            waitingForCalc
        }

        CalcStates state = CalcStates.waitingForFirstOperand;
        string firstOperand = "";
        string secondOperand = "";
        char operation;

        public Form1()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Input.Text += "0";
            
            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand += "0";
            }

            if (state == CalcStates.waitingForSecondOperand)
            {
                secondOperand += "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Input.Text += "1";

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand += "1";
            }

            if (state == CalcStates.waitingForSecondOperand)
            {
                secondOperand += "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Input.Text += "2";

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand += "2";
            }

            if (state == CalcStates.waitingForSecondOperand)
            {
                secondOperand += "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Input.Text += "3";

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand += "3";
            }

            if (state == CalcStates.waitingForSecondOperand)
            {
                secondOperand += "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Input.Text += "4";

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand += "4";
            }

            if (state == CalcStates.waitingForSecondOperand)
            {
                secondOperand += "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Input.Text += "5";

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand += "5";
            }

            if (state == CalcStates.waitingForSecondOperand)
            {
                secondOperand += "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Input.Text += "6";

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand += "6";
            }

            if (state == CalcStates.waitingForSecondOperand)
            {
                secondOperand += "6";
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Input.Text += "7";

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand += "7";
            }

            if (state == CalcStates.waitingForSecondOperand)
            {
                secondOperand += "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Input.Text += "8";

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand += "8";
            }

            if (state == CalcStates.waitingForSecondOperand)
            {
                secondOperand += "8";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Input.Text += "9";

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand += "9";
            }

            if (state == CalcStates.waitingForSecondOperand)
            {
                secondOperand += "9";
            }
        }

        private void Comma_Click(object sender, EventArgs e)
        {
            Input.Text += ",";

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand += ",";
            }

            if (state == CalcStates.waitingForSecondOperand)
            {
                secondOperand += ",";
            }
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            if (state == CalcStates.waitingForFirstOperand)
            {
                return;
            }

            state = CalcStates.waitingForCalc;
            double result = Calc();
            Input.Text = "";
            Input.Text += result;
            state = CalcStates.waitingForOperator;

            firstOperand = result.ToString();
            secondOperand = "";
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            if (state == CalcStates.waitingForSecondOperand)
            {
                Input.Text = "";
                Input.Text += Calc().ToString();
                Input.Text += "+";
                firstOperand = Calc().ToString();
                secondOperand = "";
                state = CalcStates.waitingForSecondOperand;
                operation = '+';
            }

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand = Input.Text;
                operation = '+';
                Input.Text += "+";
                state = CalcStates.waitingForSecondOperand;

                return;
            }

            if (state == CalcStates.waitingForOperator)
            {
                Input.Text += "+";
                operation = '+';
                state = CalcStates.waitingForSecondOperand;
            }
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (state == CalcStates.waitingForSecondOperand)
            {
                Input.Text = "";
                Input.Text += Calc().ToString();
                Input.Text += "-";
                firstOperand = Calc().ToString();
                secondOperand = "";
                state = CalcStates.waitingForSecondOperand;
                operation = '-';
            }

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand = Input.Text;
                operation = '-';
                Input.Text += "-";
                state = CalcStates.waitingForSecondOperand;

                return;
            }

            if (state == CalcStates.waitingForOperator)
            {
                Input.Text += "-";
                operation = '-';
                state = CalcStates.waitingForSecondOperand;
            }
        }

        private void Mult_Click(object sender, EventArgs e)
        {
            if (state == CalcStates.waitingForSecondOperand)
            {
                Input.Text = "";
                Input.Text += Calc().ToString();
                Input.Text += "*";
                firstOperand = Calc().ToString();
                secondOperand = "";
                state = CalcStates.waitingForSecondOperand;
                operation = '*';
            }

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand = Input.Text;
                operation = '*';
                Input.Text += "*";
                state = CalcStates.waitingForSecondOperand;

                return;
            }

            if (state == CalcStates.waitingForOperator)
            {
                Input.Text += "*";
                operation = '*';
                state = CalcStates.waitingForSecondOperand;
            }
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            if (state == CalcStates.waitingForSecondOperand)
            {
                Input.Text = "";
                Input.Text += Calc().ToString();
                Input.Text += "/";
                operation = '/';
                firstOperand = Calc().ToString();
                secondOperand = "";
                state = CalcStates.waitingForSecondOperand;
            }

            if (state == CalcStates.waitingForFirstOperand)
            {
                firstOperand = Input.Text;
                operation = '/';
                Input.Text += "/";
                state = CalcStates.waitingForSecondOperand;

                return;
            }

            if (state == CalcStates.waitingForOperator)
            {
                Input.Text += "/";
                operation = '/';
                state = CalcStates.waitingForSecondOperand;
            }
        }

        private double Calc()
        {
            switch (operation)
            {
                case '+':
                    return Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand);
                case '-':
                    return Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand);
                case '*':
                    return Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand);
                case '/':
                    return Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand);
                default:
                    return 0; // исключение
                    break;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Input.Text = "";
            firstOperand = "";
            secondOperand = "";
            operation = '\0';
            state = CalcStates.waitingForFirstOperand;
        }
    }
}
