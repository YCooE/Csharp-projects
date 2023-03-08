using System;

namespace TicTacToe
{
    public class Game
    {
        private Player _player;

        private bool _game_running = true;

        public Board Board { get; private set; }

        public Cursor Cursor { get; private set; }

        private Game()
        {
            Restart();
        }

        private static readonly Game s_instance = new Game();

        public static Game GetInstance { get { return s_instance; } }

        private void Play()
        {
            _player = _player.Play();
        }

        private void Restart()
        {
            Cursor = new Cursor();
            Board = new Board();
            _player = Circle.GetInstance;
        }

        private void Quit()
        {
            Console.Clear();
            Console.WriteLine("\nGood bye !");
            Environment.Exit(0);
        }

        /// <summary>
        /// Moves according to the specified key, taking into account
        /// which player currently has the turn.
        /// </summary>
        private void Move(int key)
        {
            _player.Move(key);
        }

        /// <summary>
        /// Simple key event handler.
        /// </summary>
        /// <param name="key">Key character</param>
        public void Respond(int key)
        {
            switch (key)
            {
            case ' ':
                Play();
                break;
            case 'r':
                Restart();
                break;
            case 'q':
                Quit();
                break;
            default:
                Move(key);
                break;
            }
        }

        private void DrawTitle()
        {
            Console.WriteLine("TIC-TAC-TOE\n");
        }

        private void DrawHelp()
        {
            _player.DrawHelp();
        }

        private void DrawGameTied()
        {
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("The game was a tie!");
        }

        private void DrawCircleWins()
        {
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("Circle Wins!");
        }

        private void DrawCrossWins()
        {
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("Cross Wins!");
        }

        /// <summary>
        /// Fetches the current status of the game from the
        /// state machine. A game can be either running or ended.
        /// </summary>
        private void CheckGameRunning()
        {
            switch (Board.State)
            {
            case BoardState.Tied:
                _game_running = false;
                DrawGameTied();
                break;
            case BoardState.Circle_Wins:
                _game_running = false;
                DrawCircleWins();
                break;
            case BoardState.Cross_Wins:
                _game_running = false;
                DrawCrossWins();
                break;
            case BoardState.Inconclusive:
                break;
            }
        }

        /// <summary>
        /// Draw the game by calling the constituent draw methods in order.
        /// </summary>
        private void Draw()
        {
            Console.Clear();
            DrawTitle();
            DrawHelp();

            CheckGameRunning();

            Board.Draw();
            Cursor.Draw();
        }

        /// <summary>
        /// Game loop. Called from Main method.
        /// Starts a game and keeps it running until closed.
        /// </summary>
        public void Interact()
        {
            int key;
            while (_game_running)
            {
                Draw();
                CheckGameRunning();

                key = Console.Read();
                Respond(key);
            }
        }
    }
}
