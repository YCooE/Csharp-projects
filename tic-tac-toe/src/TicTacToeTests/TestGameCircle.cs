using NUnit.Framework;
using TicTacToe;
using System;

namespace TicTacToeTests
{
    public class TestGameCircle
    {
        private Game _game;

        [SetUp()]
        public void CreateBoard()
        {
            _game = Game.GetInstance;
            _game.Respond('r');
        }

        [Test()]
        public void TestMoveDown()
        {
            _game.Respond('k');
            Assert.AreEqual(new Position(0, 1), (Position)_game.Cursor);
        }

        [Test()]
        public void TestMoveUp()
        {
            _game.Respond('k');
            _game.Respond('i');
            Assert.AreEqual(new Position(0, 0), (Position)_game.Cursor);
        }

        [Test()]
        public void TestMoveRight()
        {
            _game.Respond('l');
            Assert.AreEqual(new Position(1, 0), (Position)_game.Cursor);
        }

        [Test()]
        public void TestMoveLeft()
        {
            _game.Respond('l');
            _game.Respond('j');
            Assert.AreEqual(new Position(0, 0), (Position)_game.Cursor);
        }

        [Test()]
        public void TestRowWin()
        {
            _game.Respond(' ');
            _game.Respond('s');
            _game.Respond(' ');
            _game.Respond('i');
            _game.Respond('l');
            _game.Respond(' ');
            _game.Respond('s');
            _game.Respond(' ');
            _game.Respond('i');
            _game.Respond('l');
            _game.Respond(' ');
            Assert.AreEqual(BoardState.Circle_Wins, _game.Board.State);
        }
    }
}