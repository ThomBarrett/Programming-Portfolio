using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectSorter
{
    class Green : Color
    {
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Out.WriteLine("Green object!");
        }
    }
}
