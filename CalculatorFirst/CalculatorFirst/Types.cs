using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFirst
{
    public static class Types
    {
        public const string deleters = "DCB"; // this type needs at least 1 digit
        public const string digits = "0123456789,"; // this type doesn't need anything
        public const string operators = "+-x/=^"; // this type needs 2 numbers
        public const string modifiers = "qslL!"; //this type needs 1 digit

        public static Dictionary<string, string> moDifiersDictionary =
            new Dictionary<string, string> {
            {"q"," -/+ "},
            {"s"," sqrt "},
            {"l"," log10 "},
            {"L"," logN "},
            {"!","!"},
            };
    }
}
