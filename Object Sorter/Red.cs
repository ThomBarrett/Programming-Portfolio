using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectSorter
{
    class Red : Color
    {
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Out.WriteLine("Red object!");
        }
    }
}
