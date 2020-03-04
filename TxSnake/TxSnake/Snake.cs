namespace TxSnake
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class Snake
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Snake"/> class.
        /// </summary>
        public Snake()
        {
            /*Board = new Spot[Console.WindowWidth, Console.WindowHeight];
            Board[Head.Item1, Head.Item2] = Spot.RIGHT;*/
            Pieces = new List<Piece>();
            Pieces.Add(new Piece(Console.WindowWidth / 2, Console.WindowHeight / 2, Direction.RIGHT));
            Pieces.Add(new Piece((Console.WindowWidth / 2) - 1, Console.WindowHeight / 2, Direction.RIGHT));
            Pieces.Add(new Piece((Console.WindowWidth / 2) - 2, Console.WindowHeight / 2, Direction.RIGHT));
            Pieces.Add(new Piece((Console.WindowWidth / 2) - 3, Console.WindowHeight / 2, Direction.RIGHT));
            Pieces.Add(new Piece((Console.WindowWidth / 2) - 4, Console.WindowHeight / 2, Direction.RIGHT));
        }

        private enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
        }

        private List<Piece> Pieces { get; set; }

        private Piece Head
        {
            get { return Pieces[0]; }
        }

        private int Width { get; set; } = Console.WindowWidth;

        private int Heigth { get; set; } = Console.WindowHeight;

        //private Spot[,] Board { get; set; }

        //private (int, int) Head { get; set; } = (Console.WindowWidth / 2, Console.WindowHeight / 2);

        /* private Spot HeadSpot
         {
             get
             {
                 return Board[Head.Item1, Head.Item2];
             }
         }*/


        public static int Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Show();
            
            Snake snake = new Snake();
            snake.Play();
            return 0;
        }

        /// <summary>
        /// Start the snake game.
        /// </summary>
        public void Play()
        {
            //Console.BackgroundColor = ConsoleColor.DarkMagenta;
            int width = Console.WindowWidth;
            int heigth = Console.WindowHeight;
            ConsoleKeyInfo consoleKeyInfo;
            Console.Clear();
            Print();
            do
            {
                bool result = true;
                while (Console.KeyAvailable == false)
                {
                    if (Console.WindowWidth != width || Console.WindowHeight != heigth)
                    {
                        width = Console.WindowWidth;
                        heigth = Console.WindowHeight;
                        throw new SystemException("Window resized.");
                    }

                    result = Move(Head.Direction);
                    if (result == false)
                    {
                        throw new Exception("Game Over!");
                    }
                    Console.Clear();
                    Print();
                    Thread.Sleep(200);
                }

                consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.Key == ConsoleKey.UpArrow && Head.Direction != Direction.DOWN)
                {
                    result = Move(Direction.UP);
                }
                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow && Head.Direction != Direction.UP)
                {
                    result = Move(Direction.DOWN);
                }
                else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow && Head.Direction != Direction.RIGHT)
                {
                    result = Move(Direction.LEFT);
                }
                else if (consoleKeyInfo.Key == ConsoleKey.RightArrow && Head.Direction != Direction.LEFT)
                {
                   result = Move(Direction.RIGHT);
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Spacebar)
                {

                }

                if (result == false)
                {
                    throw new Exception("Game Over!");
                }

                Console.Clear();
                Print();

            } while (consoleKeyInfo.Key != ConsoleKey.Escape);
        }

        private bool Move(Direction direction)
        {
            Head.Direction = direction;

            // Check collision with borders
            if ((Head.Direction == Direction.UP && Head.Top == 0) ||
                (Head.Direction == Direction.DOWN && Head.Top == Heigth - 1) ||
                (Head.Direction == Direction.LEFT && Head.Left == 0) ||
                (Head.Direction == Direction.RIGHT && Head.Left == Width - 1))
            {
                return false;
            }

            // Check collision with snake
            foreach (Piece piece in Pieces)
            {
                if (((Head.Direction == Direction.UP) &&
                    (piece.Direction == Direction.LEFT || piece.Direction == Direction.RIGHT) &&
                    (piece.Top == Head.Top - 1) &&
                    ((piece.Left - 1 == Head.Left) || (piece.Left + 1 == Head.Left)))
                    ||
                    ((Head.Direction == Direction.DOWN) &&
                    (piece.Direction == Direction.LEFT || piece.Direction == Direction.RIGHT) &&
                    (piece.Top == Head.Top + 1) &&
                    ((piece.Left - 1 == Head.Left) || (piece.Left + 1 == Head.Left)))
                    ||
                    ((Head.Direction == Direction.RIGHT) &&
                    (piece.Direction == Direction.UP || piece.Direction == Direction.DOWN) &&
                    (piece.Left == Head.Left + 1) &&
                    ((piece.Top - 1 == Head.Top) || (piece.Top + 1 == Head.Top)))
                    ||
                    ((Head.Direction == Direction.LEFT) &&
                    (piece.Direction == Direction.UP || piece.Direction == Direction.DOWN) &&
                    (piece.Left == Head.Left - 1) &&
                    ((piece.Top - 1 == Head.Top) || (piece.Top + 1 == Head.Top))))
                {
                    return false;
                }
            }

            Direction predecessor = Head.Direction;

            foreach (Piece piece in Pieces)
            {
                if (piece.Direction == Direction.UP)
                {
                    piece.Top -= 1;
                }
                else if (piece.Direction == Direction.DOWN)
                {
                    piece.Top += 1;
                }
                else if (piece.Direction == Direction.LEFT)
                {
                    piece.Left -= 1;
                }
                else if (piece.Direction == Direction.RIGHT)
                {
                    piece.Left += 1;
                }

                Direction dummy = piece.Direction;
                piece.Direction = predecessor;
                predecessor = dummy;
            }

            return true;
        }

        private void Print()
        {
            foreach (Piece piece in Pieces)
            {
                Console.SetCursorPosition(piece.Left, piece.Top);
                Console.Write("#");

            }
        }

        private class Piece
        {
            public Piece(int l, int t, Direction direction)
            {
                Left = l;
                Top = t;
                Direction = direction;
            }

            public int Left { get; set; }

            public int Top { get; set; }

            public Direction Direction { get; set; }
        }
    }
}