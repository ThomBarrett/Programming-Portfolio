using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectSorter
{
    class Brown : Color
    {
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Out.WriteLine("Brown object!");
        }
    }
}
