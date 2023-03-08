using NUnit.Framework;
using TicTacToe;
using System;

namespace TicTacToeTests
{
    public class TestGameCross
    {
        private Game _game;

        [SetUp()]
        public void CreateBoard()
        {
            _game = Game.GetInstance;
            _game.Respond('r');
            _game.Respond(' ');
        }

        [Test()]
        public void TestMoveDown()
        {
            _game.Respond('s');
            Assert.AreEqual(new Position(0, 1), (Position)_game.Cursor);
        }

        [Test()]
        public void TestMoveUp()
        {
            _game.Respond('s');
            _game.Respond('w');
            Assert.AreEqual(new Position(0, 0), (Position)_game.Cursor);
        }

        [Test()]
        public void TestMoveRight()
        {
            _game.Respond('d');
            Assert.AreEqual(new Position(1, 0), (Position)_game.Cursor);
        }

        [Test()]
        public void TestMoveLeft()
        {
            _game.Respond('d');
            _game.Respond('a');
            Assert.AreEqual(new Position(0, 0), (Position)_game.Cursor);
        }

        [Test()]
        public void TestRowWin()
        {
            _game.Respond('s');
            _game.Respond(' ');
            _game.Respond('k');
            _game.Respond(' ');
            _game.Respond('w');
            _game.Respond('d');
            _game.Respond(' ');
            _game.Respond('i');
            _game.Respond('l');
            _game.Respond(' ');
            _game.Respond('s');
            _game.Respond(' ');
            Assert.AreEqual(BoardState.Cross_Wins, _game.Board.State);
        }
    }
}