using System;
using Tree;

namespace BinaryTree
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            BinTree ti = new BinTree (1);
            Console.WriteLine (ti);

            ti.left = new BinTree (2);
            Console.WriteLine (ti);

            ti.right = new BinTree (3);
            Console.WriteLine (ti);

            string hej = "hej";
            string med = "med";
            string dig = "dig";

            Console.WriteLine ("{0} {1} {2}", hej, med, dig);
        }
    }
}
