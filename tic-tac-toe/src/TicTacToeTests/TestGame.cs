using NUnit.Framework;
using TicTacToe;
using System;

namespace TicTacToeTests
{
    public class TestGame
    {
        private Game _game;

        [SetUp()]
        public void CreateBoard()
        {
            _game = Game.GetInstance;
            _game.Respond('r');
        }

        [Test()]
        public void TestInitialCursorPosition()
        {
            Assert.AreEqual(new Position(0, 0), (Position)_game.Cursor);
        }

        [Test()]
        public void TestInitialBoardState()
        {
            Assert.AreEqual(BoardState.Inconclusive, _game.Board.State);
        }
    }
}