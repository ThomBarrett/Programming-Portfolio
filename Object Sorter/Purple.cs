using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectSorter
{
    class Purple : Color
    {
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Out.WriteLine("Purple object!");
        }
    }
}
