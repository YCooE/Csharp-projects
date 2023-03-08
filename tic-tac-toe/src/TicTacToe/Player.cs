using System;

namespace TicTacToe
{
    public abstract class Player
    {
        public abstract bool Move(int key);

        public abstract Player Play();

        public abstract void DrawHelp();
    }

    public class Circle : Player
    {
        private Circle()
        {
            // This is just to make this a singleton.
        }

        private static Circle s_instance = new Circle();

        public static Circle GetInstance { get { return s_instance; } }

        public override bool Move(int key)
        {
            Cursor c = Game.GetInstance.Cursor;
            bool moved = false;

            switch (key)
            {
            case 'i':
                c.MoveUp();
                moved = true;
                break;
            case 'j':
                c.MoveLeft();
                moved = true;
                break;
            case 'k':
                c.MoveDown();
                moved = true;
                break;
            case 'l':
                c.MoveRight();
                moved = true;
                break;
            }

            return moved;
        }

        public override Player Play()
        {
            Board b = Game.GetInstance.Board;
            Cursor c = Game.GetInstance.Cursor;

            if (b.PlayCircle(c))
            {
                return Cross.GetInstance;
            }
            else
            {
                return this;
            }
        }

        public override void DrawHelp()
        {
            Console.WriteLine("Circle has the turn.");
            Console.WriteLine("Use <i>, <j>, <k>, and <l> to move.");
            Console.WriteLine("Press <space> to insert circle.\n");
        }
    }

    public class Cross : Player
    {
        private Cross()
        {
            // This is just to make this a singleton.
        }

        private static Cross s_instance = new Cross();

        public static Cross GetInstance { get { return s_instance; } }

        public override bool Move(int key)
        {
            Cursor c = Game.GetInstance.Cursor;
            bool moved = false;

            switch (key)
            {
            case 'w':
                c.MoveUp();
                moved = true;
                break;
            case 'a':
                c.MoveLeft();
                moved = true;
                break;
            case 's':
                c.MoveDown();
                moved = true;
                break;
            case 'd':
                c.MoveRight();
                moved = true;
                break;
            }

            return moved;
        }

        public override Player Play()
        {
            Board b = Game.GetInstance.Board;
            Cursor c = Game.GetInstance.Cursor;

            if (b.PlayCross(c))
            {
                return Circle.GetInstance;
            }
            else
            {
                return this;
            }
        }

        public override void DrawHelp()
        {
            Console.WriteLine("Cross  has the turn.");
            Console.WriteLine("Use <w>, <a>, <s>, and <d> to move.");
            Console.WriteLine("Press <space> to insert cross.\n");
        }
    }
}