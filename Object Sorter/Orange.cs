using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectSorter
{
    class Orange : Color
    {
        public void Print() {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Out.WriteLine("Orange object!");
        }
    }
}
