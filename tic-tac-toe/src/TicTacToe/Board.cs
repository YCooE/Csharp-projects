using System;

namespace TicTacToe
{
    /// <summary>
    /// State machine class. Maintains an internal game board
    /// which it can draw, place turns in, and check if a
    /// game is won.
    /// </summary>
    public class Board
    {
        private Cell[,] _cells;

        private int _n_places = 0;
        private int _max_places = Constants.SIZE * Constants.SIZE;

        public BoardState State { get; private set; }

        public Board()
        {
            _cells = new Cell[Constants.SIZE, Constants.SIZE];
            State = BoardState.Inconclusive;
        }

        /// <summary>
        /// Places a circle at the specified position
        /// if that position is empty.
        /// </summary>
        public bool PlayCircle(Position pos)
        {
            return PlayCircle(ref _cells[pos.Y, pos.X]);
        }

        private bool PlayCircle(ref Cell cell)
        {
            bool retval = false;

            switch (cell)
            {
            case Cell.Empty:
                _n_places += 1;
                cell = Cell.Circle;
                retval = true;
                CheckGameEnded();
                break;
            }

            return retval;
        }

        /// <summary>
        /// Places a cross at the specified position
        /// if that position is empty.
        /// </summary>
        public bool PlayCross(Position pos)
        {
            return PlayCross(ref _cells[pos.Y, pos.X]);
        }

        private bool PlayCross(ref Cell cell)
        {
            bool retval = false;

            switch (cell)
            {
            case Cell.Empty:
                _n_places += 1;
                cell = Cell.Cross;
                retval = true;
                CheckGameEnded();
                break;
            }

            return retval;
        }

        /// <summary>
        /// Determines if either player has 3-in-a-row,
        /// in which case the game is over.
        /// </summary>
        private void CheckGameEnded()
        {
            if (IsGameOver(Cell.Circle))
            {
                State = BoardState.Circle_Wins;
            }
            else if (IsGameOver(Cell.Cross))
            {
                State = BoardState.Cross_Wins;
            }
            else if (_n_places >= _max_places)
            {
                State = BoardState.Tied;
            }
        }

        /// <summary>
        /// check all possible combinations for the target cell
        /// of winning the game (row, column, or slope).
        /// </summary>
        private bool IsGameOver(Cell cell)
        {
            int slope_backward = 0;
            int slope_forward = 0;

            for (int i = 0; i < Constants.SIZE; i++)
            {
                int row = 0;
                int col = 0;
                for (int j = 0; j < Constants.SIZE; j++)
                {
                    if (_cells[i, j] == cell)
                    {
                        row += 1;
                    }
                    if (_cells[j, i] == cell)
                    {
                        col += 1;
                    }
                }

                if (row == Constants.SIZE || col == Constants.SIZE)
                {
                    return true;
                }

                if (_cells[i, i] == cell)
                {
                    slope_backward += 1;
                }

                if (_cells[i, Constants.MAX_INDEX - i] == cell)
                {
                    slope_forward += 1;
                }
            }

            return (slope_backward == Constants.SIZE || slope_forward == Constants.SIZE);
        }

        /// <summary>
        /// Draw the game board with its associated borders.
        /// </summary>
        public void Draw()
        {
            Console.WriteLine("+---+");
            for (int i = 0; i < Constants.SIZE; i++)
            {
                Console.Write("|");
                for (int j = 0; j < Constants.SIZE; j++)
                {
                    _cells[i, j].Draw();
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("+---+");
        }
    }
}
