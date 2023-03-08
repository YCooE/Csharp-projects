using FsCheck;
using TicTacToe;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToeTests
{
    public abstract class Test
    {
        private FsCheck.Random.StdGen _random;
        private int _size;

        public Test()
        {
            _random = FsCheck.Random.mkStdGen(1000);
            _size = 10;
        }

        protected a Eval<a>(Gen<a> gen)
        {
            return gen.Eval(_size, _random);
        }

        protected IEnumerable<a> Shuffle<a>(IEnumerable<a> col)
        {
            return Eval(Gen.Shuffle(col));
        }

        /// <summary>
        /// Generate a random number between l and h, inclusive.
        /// </summary>
        protected int Choose(int l, int h)
        {
            return Eval(Gen.Choose(l, h));
        }

        protected Gen<Position> Position
        {
            get {
                return
                from x in Gen.Choose(0, Constants.SIZE - 1)
                            from y in Gen.Choose(0, Constants.SIZE - 1)
                            select new Position(x, y);
            }
        }

        protected IEnumerable<Position> SomeRandomPositions()
        {
            return Eval(Gen.ListOf(Position));
        }
    }
}