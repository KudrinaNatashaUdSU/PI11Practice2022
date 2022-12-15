using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CALC
{
    public class Calculator 
    {
        enum State //состояния калькулятора
        {
            in1, //ввод1
            oper, //операция
            in2, //ввод2
            ans, //ответ
            err //ошибка
        }
        string? screen; //на экране
        string? memory; //запоминание первого числа
        string? op; //операция
        State state; //состояние
        string res = "0"; //результат
        public string Screen //получить значение с экрана
        {
            get { return screen!; }
        }
        public Calculator() //конструктор калькулятора
        {
            screen = "0";
            memory = "";
            op = "";
            state = State.in1;
        }
        public void DoCommand(string cmd) //реакция на нажатие кнопок
        {
            switch (cmd)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    DigitCase(cmd);
                    break;
                case "0":
                    ZeroCase(cmd);
                    break;
                case ".":
                    PointCase(cmd);
                    break;
                case "-/+":
                    if ((state == State.in1 || state == State.ans || state == State.in2) && screen != "0")
                    {
                        if (screen.Contains("-")) screen = screen.Replace("-", "");
                        else screen = "-" + screen; 
                    }
                    break;
                case "+":
                case "-":
                case "/":
                case "*":
                    OperCase(cmd);
                    break;
                case "=":
                    EqualCase(cmd);
                    break;
                case "C":
                    screen = "0";
                    memory = "";
                    op = "";
                    state = State.in1;
                    break;
            }
        }
        public void calc(string cmd)  //выполнение операции
        {
            switch (cmd)
            {
                case "+":
                    res = Convert.ToString(Convert.ToDouble(memory, CultureInfo.InvariantCulture) + Convert.ToDouble(screen, CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                    break;
                case "-":
                    res = Convert.ToString(Convert.ToDouble(memory, CultureInfo.InvariantCulture) - Convert.ToDouble(screen, CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                    break;
                case "/":
                    res = Convert.ToString(Convert.ToDouble(memory, CultureInfo.InvariantCulture) / Convert.ToDouble(screen, CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                    break;
                case "*":
                    res = Convert.ToString(Convert.ToDouble(memory, CultureInfo.InvariantCulture) * Convert.ToDouble(screen, CultureInfo.InvariantCulture), CultureInfo.InvariantCulture); 
                    break;
            }
        }

        public void DigitCase(string cmd) //1-9 из DoCommand
        {
            if (state == State.in1)
            {
                if (screen == "0") screen = cmd;
                else screen += cmd;
            }
            else if (state == State.oper)
            {
                screen = cmd;
                state = State.in2;
            }
            else if (state == State.in2)
            {
                if (screen == "0") screen = cmd;
                else screen += cmd;
            }
            else if (state == State.ans)
            {
                screen += cmd;
                state = State.in1;
            }
        }

        public void  ZeroCase(string cmd) //0 из DoCommand
        {
            if (state == State.in1)
            {
                if (screen != "0") screen += "0";
            }
            else if (state == State.oper)
            {
                screen = "0";
                state = State.in2;
            }
            else if (state == State.in2)
            {
                if (screen != "0") screen += "0";
            }
            else if (state == State.ans) screen = "0";
        }

        public void OperCase(string cmd) // + - / * из DoCommand
        {
            if (state == State.in1 || state == State.ans)
            {
                memory = screen;
                op = cmd;
                state = State.oper;
            }
            else if (state == State.oper)
            {
                op = cmd;
                //op <- НОВАЯ
            }
            else if (state == State.in2)
            {
                calc(cmd);
                screen = res;
                op = cmd;
                //op <- НОВАЯ  
                state = State.oper;
                return;
            }
        }

        public void PointCase(string cmd) // . из DoCommand
        {
            if (state == State.in1 || state == State.in2)
            {
                if (!screen!.Contains("."))
                {
                    screen += ".";
                }
            }
            else if (state == State.oper || state == State.ans)
            {
                screen = "0.";
                state = state == State.oper ? State.in2 : State.in1;
            }
        }

        public void EqualCase(string cmd) // = из DoCommand
        {
            if (state == State.oper || state == State.in2 || state == State.ans)
            {
                if (op == "/" && screen == "0")
                {
                    screen = "ERROR";
                    state = State.err;
                }
                else if (op == "+" || op == "-" || op == "/" || op == "*")
                {
                    calc(op);
                    screen = res;
                    state = State.ans;
                }
            }
        }
    }
}
