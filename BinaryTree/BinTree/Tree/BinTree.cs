using System;
using System.Text;

namespace Tree
{
    public class BinTree
    {

        public int value;
        public BinTree left;
        public BinTree right;

        public BinTree (int value)
        {
            this.value = value;
            left = null;
            right = null;
        }

        public override string ToString ()
        {
            StringBuilder str = new StringBuilder ();

            str.Append ("Node");
            str.Append ((left == null) ? "(Leaf" : String.Format("({0}", left.ToString()));
            str.Append (String.Format(", {0}, ", value));
            str.Append ((right == null) ? "Leaf)" : String.Format("{0})", right.ToString()));

            return str.ToString ();
        }
    }
}
