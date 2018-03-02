using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectSorter
{
    class Gray : Color
    {
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Out.WriteLine("Gray object!");
        }
    }
}
