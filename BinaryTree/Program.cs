using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            bt.Insert(2);
            bt.Insert(1);
            bt.Insert(3);
            bt.Insert(0);

            bt.TraversePreorder();

            Console.ReadLine();
        }
    }
}
