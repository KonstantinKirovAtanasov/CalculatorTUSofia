using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFirst
{
    public static class Manipulator
    {
        /// <summary>
        /// Gets the Operation line and Calculate the end Result
        /// </summary>
        internal static void Calculate(double a, double b, string Operator, out double result)
        {
            switch (Operator)
            {
                case "+": result = a + b;return;
                case "-": result = a - b;return;
                case "x": result = a * b;return;
                case "/":
                    {
                        if (b != 0)
                            result = a / b;
                        else
                            result = double.NaN;
                            return;
                    }
                case "^": result = Math.Pow(a, b); return;
                default:result = a;return;
            }
            
        }
        internal static void AddDigit(string param, ref string current)
        {
            if (param.Equals(","))
            {
                if (current.Length == 0)
                    current = "0,";
                if (current.Contains(','))
                    return;
                else
                    current += param;
            }
            else if (current.Equals("0"))
                current = param;
            else
                current += param;
        }

        internal static void AddOperation(string param, ref string container)
        {
            container = param;
        }

        internal static void Delete(string symbol, ref string container)
        {
            switch (symbol){
                case "B":container = container.Substring(0, container.Length-1);return;
                case "C": container = ""; return;
                default: return;
            }
        }

        internal static void CalculateModifier(string currentSympolInput, ref string container)
        {
            double number = double.Parse(container);
            switch (currentSympolInput)
            {
                case "q": number*=-1; break;
                case "s":number = Math.Sqrt(number);break;
                case "L": number = Math.Log(number); break;
                case "l": number = Math.Log10(number); break;
                case "!": number = CalculateFactorial(number); break;

                default: return;
            }
            container = number.ToString();
        }

        private static ulong CalculateFactorial(double d)
        {
            int NumForCalc = (int)d;
            ulong result = 1;
            if((NumForCalc - d) < 0.000000001)
            {
                for (int i = NumForCalc; i > 1; i--)
                    result = result*(ulong)i;
            }
            return result;
        }
    }
}
