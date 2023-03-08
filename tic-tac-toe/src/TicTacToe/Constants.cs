using System;

namespace TicTacToe
{
    /// <summary>
    /// Constants used in the game.
    /// Defines size of the game board.
    /// </summary>
    public static class Constants
    {
        public const int SIZE = 3;
        public const int MAX_INDEX = SIZE - 1;

        public const int MIN_X = 1;
        public const int MAX_X = MIN_X + SIZE - 1;
        public const int MIN_Y = 7;
        public const int MAX_Y = MIN_Y + SIZE - 1;
    }
}
