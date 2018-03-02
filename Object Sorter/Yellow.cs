using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectSorter
{
    class Yellow : Color
    {
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Out.WriteLine("Yellow object!");
        }
    }
}
