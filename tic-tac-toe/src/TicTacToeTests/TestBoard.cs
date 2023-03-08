using NUnit.Framework;
using TicTacToe;
using System;

namespace TicTacToeTests
{
    [TestFixture()]
    public class TestBoard : Test
    {
        private static Board _board;

        [SetUp()]
        public void CreateBoard()
        {
            _board = new Board();
        }

        [Test()]
        public void TestNoMoves()
        {
            Assert.AreEqual(_board.State, BoardState.Inconclusive);
        }

        public delegate bool Play(Position p);

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void TestCircleRow(int row)
        {
            var moves = Shuffle(new Position[] {
                new Position(0, row),
                new Position(1, row),
                new Position(2, row)
            });

            foreach (Position move in moves)
            {
                _board.PlayCircle(move);
            }

            Assert.AreEqual(_board.State, BoardState.Circle_Wins);
        }
            
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void TestCircleColumn(int column)
        {
            var moves = Shuffle(new Position[] {
                new Position(column, 0),
                new Position(column, 1),
                new Position(column, 2)
            });

            foreach (Position move in moves)
            {
                _board.PlayCircle(move);
            }

            Assert.AreEqual(_board.State, BoardState.Circle_Wins);
        }

        [Test()]
        public void TestCirclePositiveSlope()
        {
            var moves = Shuffle(new Position[] {
                new Position(0, 2),
                new Position(1, 1),
                new Position(2, 0)
            });

            foreach (Position move in moves)
            {
                _board.PlayCircle(move);
            }

            Assert.AreEqual(_board.State, BoardState.Circle_Wins);
        }

        [Test()]
        public void TestCircleNegativeSlope()
        {
            var moves = Shuffle(new Position[] {
                new Position(0, 0),
                new Position(1, 1),
                new Position(2, 2)
            });

            foreach (Position move in moves)
            {
                _board.PlayCircle(move);
            }

            Assert.AreEqual(_board.State, BoardState.Circle_Wins);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void TestCrossRow(int row)
        {
            var moves = Shuffle(new Position[] {
                new Position(0, row),
                new Position(1, row),
                new Position(2, row)
            });

            foreach (Position move in moves)
            {
                _board.PlayCross(move);
            }

            Assert.AreEqual(_board.State, BoardState.Cross_Wins);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void TestCrossColumn(int column)
        {
            var moves = Shuffle(new Position[] {
                new Position(column, 0),
                new Position(column, 1),
                new Position(column, 2)
            });

            foreach (Position move in moves)
            {
                _board.PlayCross(move);
            }

            Assert.AreEqual(_board.State, BoardState.Cross_Wins);
        }

        [Test()]
        public void TestCrossPositiveSlope()
        {
            var moves = Shuffle(new Position[] {
                new Position(0, 2),
                new Position(1, 1),
                new Position(2, 0)
            });

            foreach (Position move in moves)
            {
                _board.PlayCross(move);
            }

            Assert.AreEqual(_board.State, BoardState.Cross_Wins);
        }

        [Test()]
        public void TestCrossNegativeSlope()
        {
            var moves = Shuffle(new Position[] {
                new Position(0, 0),
                new Position(1, 1),
                new Position(2, 2)
            });

            foreach (Position move in moves)
            {
                _board.PlayCross(move);
            }

            Assert.AreEqual(_board.State, BoardState.Cross_Wins);
        }

        [Test()]
        public void TestCrossStaysTheWinner()
        {
            var moves = Shuffle(new Position[] {
                new Position(0, 0),
                new Position(1, 1),
                new Position(2, 2)
            });

            foreach (Position move in moves)
            {
                _board.PlayCross(move);
            }

            foreach (Position move in SomeRandomPositions())
            {
                _board.PlayCircle(move);
            }

            foreach (Position move in SomeRandomPositions())
            {
                _board.PlayCross(move);
            }

            Assert.AreEqual(BoardState.Cross_Wins, _board.State);
        }

        [Test()]
        public void TestCircleStaysTheWinner()
        {
            var moves = Shuffle(new Position[] {
                new Position(0, 0),
                new Position(1, 1),
                new Position(2, 2)
            });

            foreach (Position move in moves)
            {
                _board.PlayCircle(move);
            }

            foreach (Position move in SomeRandomPositions())
            {
                _board.PlayCross(move);
            }

            foreach (Position move in SomeRandomPositions())
            {
                _board.PlayCross(move);
            }

            Assert.AreEqual(BoardState.Circle_Wins, _board.State);
        }

        [Test()]
        public void TestRunning()
        {
            _board.PlayCircle(new Position(0, 0));
            _board.PlayCross(new Position(0, 1));
            _board.PlayCircle(new Position(0, 2));
            Assert.AreEqual(_board.State, BoardState.Inconclusive);
        }
    }
}