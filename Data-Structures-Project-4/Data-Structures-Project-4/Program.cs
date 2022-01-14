using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_Project_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AVLTree tree = new AVLTree();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(2);
            tree.Delete(7);
            tree.Add(3423);
            tree.Add(11);
            tree.Add(6);
            tree.DisplayTree();

            Console.ReadKey();

        }
    }
}
