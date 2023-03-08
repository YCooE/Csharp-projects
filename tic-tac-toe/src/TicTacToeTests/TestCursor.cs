using NUnit.Framework;
using TicTacToe;
using System;

namespace TicTacToeTests
{
    public class TestCursor
    {
        private Cursor _cursor;

        [SetUp()]
        public void CreateBoard()
        {
            _cursor = new Cursor();
        }

        [Test()]
        public void TestNoMoves()
        {
            Position pos = _cursor;

            Assert.AreEqual(pos, new Position(0,0));
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestMoveDown(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _cursor.MoveDown();
            }

            Assert.AreEqual(new Position(0, n), (Position)_cursor);
        }

        [TestCase(3)]
        [TestCase(6)]
        public void TestMoveDownTooMuch(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _cursor.MoveDown();
            }

            Assert.AreEqual(
                new Position(0, Constants.SIZE - 1),
                (Position)_cursor);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestMoveUp(int n)
        {
            Position origin = _cursor;

            for (int i = 0; i < n; i++)
            {
                _cursor.MoveDown();
            }

            for (int i = 0; i < n; i++)
            {
                _cursor.MoveUp();
            }

            Assert.AreEqual(origin, (Position)_cursor);
        }

        [TestCase(3)]
        [TestCase(6)]
        public void TestMoveUpTooMuch(int n)
        {
            Position origin = _cursor;

            for (int i = 0; i < n; i++)
            {
                _cursor.MoveDown();
            }

            for (int i = 0; i < n; i++)
            {
                _cursor.MoveUp();
            }

            Assert.AreEqual(origin, (Position)_cursor);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestMoveRight(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _cursor.MoveRight();
            }

            Assert.AreEqual(new Position(n, 0), (Position)_cursor);
        }

        [TestCase(3)]
        [TestCase(6)]
        public void TestMoveRightTooMuch(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _cursor.MoveRight();
            }

            Assert.AreEqual(
                new Position(Constants.SIZE - 1, 0),
                (Position)_cursor);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestMoveLeft(int n)
        {
            Position origin = _cursor;

            for (int i = 0; i < n; i++)
            {
                _cursor.MoveRight();
            }

            for (int i = 0; i < n; i++)
            {
                _cursor.MoveLeft();
            }

            Assert.AreEqual(origin, (Position)_cursor);
        }

        [TestCase(3)]
        [TestCase(6)]
        public void TestMoveLeftTooMuch(int n)
        {
            Position origin = _cursor;

            for (int i = 0; i < n; i++)
            {
                _cursor.MoveRight();
            }

            for (int i = 0; i < n; i++)
            {
                _cursor.MoveLeft();
            }

            Assert.AreEqual(origin, (Position)_cursor);
        }
    }
}