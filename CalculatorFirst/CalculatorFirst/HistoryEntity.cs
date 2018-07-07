using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorFirst
{
    class HistoryEntity
    {
        public List<string> history = new List<string>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var s in history)
                sb.Append(s + "\n");
            return sb.ToString();
        }
    }
}
