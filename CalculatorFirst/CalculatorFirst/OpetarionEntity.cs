using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFirst
{
    public class OpetarionEntity
    {
        private string containerA = "";
        private string containerB = "";

        private string OperatorA = "";
        private string OperatorB = "";

        private string Result = "";
        public List<string> History = new List<string>();

        private string CurrentSympolInput = "";

        public OpetarionEntity() { }

        public void AddSymbol(string Symbol)
        {
            InspectAndRepair(ref containerA);
            InspectAndRepair(ref containerB);
            CurrentSympolInput = Symbol.Substring(Symbol.Length - 1);
            if (Types.operators.Contains(CurrentSympolInput))
            {
                IfIsOperator(); 
            }
            else if (Types.digits.Contains(CurrentSympolInput))
            {
                IfIsDigit();
            }
            else if (Types.deleters.Contains(CurrentSympolInput))
            {
                IfIsDeleter();
            }
            else if (Types.modifiers.Contains(CurrentSympolInput))
            {
                IfIsModifier();
            }
        }

        private void Calculate()
        {
            try
            {
                double res;
                Manipulator.Calculate(double.Parse(containerA),
                    double.Parse(containerB), OperatorA, out res);
                Result = res.ToString();
                History.Add(containerA +" "+ OperatorA +" "+ containerB + " = " + Result);
            }
            catch (FormatException) { // Do nothing it is just empty container
            }
        }

        private void IfIsDigit()
        {
            if (OperatorA.Equals(""))
            {
                Manipulator.AddDigit(CurrentSympolInput, ref containerA);
            }
            else
            {
                Manipulator.AddDigit(CurrentSympolInput, ref containerB);
            }
        }
        private void IfIsOperator()
        {
            if (containerA.Equals("")) return;
            if (containerB.Equals(""))
            {
                Manipulator.AddOperation(CurrentSympolInput, ref OperatorA);
            }
            else
            {
                Manipulator.AddOperation(CurrentSympolInput, ref OperatorB);
                Calculate();
                OperatorA = OperatorB;
                containerA = Result;
                containerB = "";
                OperatorB = "";
            }
            if (CurrentSympolInput.Equals("="))
            {
                Calculate();
                containerA = Result;
                containerB = "";
                OperatorA = "";
                OperatorB = "";
            }
        }
        private void IfIsDeleter()
        {
            if (CurrentSympolInput.Equals("D"))
            {
                OperatorA = "";
                OperatorB = "";
                containerA = "";
                containerB = "";
                History.Clear();
            }
            else if (!OperatorB.Equals(""))
            {
                Manipulator.Delete(CurrentSympolInput, ref OperatorB);
            }
            else if (!containerB.Equals(""))
            {
                Manipulator.Delete(CurrentSympolInput, ref containerB);
            }
            else if (!OperatorA.Equals(""))
            {
                Manipulator.Delete(CurrentSympolInput, ref OperatorA);
            }
            else if (!containerA.Equals(""))
            {
                Manipulator.Delete(CurrentSympolInput, ref containerA);
            }
            return;
        }
        private void IfIsModifier()
        {
            StringBuilder historyResult = new StringBuilder();
            if (!containerB.Equals("") && OperatorB.Equals(""))
            {
                historyResult.Append(containerB);
                Manipulator.CalculateModifier(CurrentSympolInput, ref containerB);
                historyResult.Append(Types.moDifiersDictionary.First(x =>
                    x.Key.Equals(CurrentSympolInput)).Value);
            }
            if (!containerA.Equals("") && OperatorA.Equals(""))
            {
                historyResult.Append(containerA);
                Manipulator.CalculateModifier(CurrentSympolInput, ref containerA);
                historyResult.Append(Types.moDifiersDictionary.First(x =>
                        x.Key.Equals(CurrentSympolInput)).Value);
            }
            historyResult.Append("=" + containerA);
            History.Add(historyResult.ToString());
        }

        public override string ToString()
        {
            return containerA + OperatorA + containerB + OperatorB;
        }

        private static void InspectAndRepair(ref string container)
        {
            if (container.Contains(double.NegativeInfinity.ToString()))
                container = container.Substring(2,container.Length-2);
            else if (container.Contains(double.PositiveInfinity.ToString()))
                container = container.Substring(1, container.Length - 1);
            else if (container.Contains(double.NaN.ToString()))
                container = container.Substring(3, container.Length - 3);
        }
    }
}
