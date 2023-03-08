using System;

namespace TicTacToe
{
    public struct Position
    {
        private int _x;
        private int _y;

        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X { get { return _x; } set { _x = value; } }

        public int Y { get { return _y; } set { _y = value; } }

        public override string ToString()
        {
            return string.Format("({0}, {1})", _x, _y);
        }

        public static bool operator ==(Position p, Position q)
        {
            return p._x == q._x && p._y == q._y;
        }

        public static bool operator !=(Position p, Position q)
        {
            return !(p == q);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Position))
            {
                return false;
            }

            return this == (Position)obj;
        }

        public override int GetHashCode()
        {
            // Source: http://stackoverflow.com/a/263416/5801152
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + _x.GetHashCode();
                hash = hash * 23 + _y.GetHashCode();
                return hash;
            }
        }
    }
}