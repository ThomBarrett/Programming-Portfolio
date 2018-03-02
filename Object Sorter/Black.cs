using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectSorter
{
    class Black : Color
    {
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Out.WriteLine("Black object!");
        }
    }
}
