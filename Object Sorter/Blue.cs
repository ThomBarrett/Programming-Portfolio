using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectSorter
{
    class Blue : Color
    {
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Out.WriteLine("Blue object!");
        }
    }
}
