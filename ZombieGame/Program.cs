using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "2D days to die";
            Console.CursorVisible = false;
            Title title = new Title();
            title.Display();
            GameWorld gameWorld = new GameWorld(title.Input());
            
            Console.Read();
        }
    }
}
