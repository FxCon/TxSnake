using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace TxSnake
{
    class Menu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
        }   

        /// <summary>
        /// Shows the menu on the console.
        /// </summary>
        public void Show()
        {
            //Console.BackgroundColor = ConsoleColor.DarkMagenta;
            int width = Console.WindowWidth;
            int heigth = Console.WindowHeight;
            int focused = 0;
            ConsoleKeyInfo consoleKeyInfo;

            PrintMenu(focused);
            do
            {
                while (Console.KeyAvailable == false)
                {
                    if (Console.WindowWidth != width || Console.WindowHeight != heigth)
                    {
                        width = Console.WindowWidth;
                        heigth = Console.WindowHeight;
                        PrintMenu(focused);
                    }

                    Thread.Sleep(200);
                }

                consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.Key == ConsoleKey.UpArrow && focused != 0)
                {
                    focused -= 1;
                    PrintMenu(focused);
                }
                else if (consoleKeyInfo.Key == ConsoleKey.DownArrow && focused != 2)
                {
                    focused += 1;
                    PrintMenu(focused);
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    if (focused == 0)
                    {
                        return;
                    } else if (focused == 1)
                    {
                        ShowHowToPlay();
                        PrintMenu(focused);
                    } else if (focused == 2)
                    {
                        return;
                    }
                }

            } while (consoleKeyInfo.Key != ConsoleKey.Escape);
        }

        private void PrintMenu(int focused)
        {
            Console.Clear();
            PrintBox();
            PrintMenuText(focused);
        }

        private void PrintBox()
        {
            // Print top line
            Console.SetCursorPosition(Console.WindowWidth * 1 / 6, Console.WindowHeight * 1 / 6);
            Console.Write("\u250C");
            Console.Write(new string('\u2500', (Console.WindowWidth * 4 / 6) - 2));
            Console.Write("\u2510");

            // Print left line
            Console.SetCursorPosition(Console.WindowWidth * 1 / 6, Console.WindowHeight * 1 / 6);
            for (int i = (Console.WindowHeight * 1 / 6) + 1; i < (Console.WindowHeight * 5 / 6); ++i)
            {
                Console.SetCursorPosition(Console.WindowWidth * 1 / 6, i);
                Console.Write("\u2502");
            }

            // Print right line
            Console.SetCursorPosition(Console.WindowWidth * 5 / 6, Console.WindowHeight * 1 / 6);
            for (int i = (Console.WindowHeight * 1 / 6) + 1; i < (Console.WindowHeight * 5 / 6); ++i)
            {
                Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (Console.WindowWidth * 4 / 6) - 1, i);
                Console.Write("\u2502");
            }

            // Print bottom line
            Console.SetCursorPosition(Console.WindowWidth * 1 / 6, Console.WindowHeight * 5 / 6);
            Console.Write("\u2514");
            Console.Write(new string('\u2500', (Console.WindowWidth * 4 / 6) - 2));
            Console.Write("\u2518");
        }

        private void PrintMenuText(int focused)
        {
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 2);
            Console.Write("  ___                 _         ");
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 3);
            Console.Write(" / __|  _ _    __ _  | |__  ___ ");
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 4);
            Console.Write(" \\__ \\ | ' \\  / _` | | / / / -_)");
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 5);
            Console.Write(" |___/ |_||_| \\__,_| |_\\_\\ \\___|");

            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 4) / 2), (Console.WindowHeight * 1 / 6) + 8);
            if (focused == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("PLAY");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write("PLAY");
            }


            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 12) / 2), (Console.WindowHeight * 1 / 6) + 10);
            if (focused == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("HOW TO PLAY?");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write("HOW TO PLAY?");
            }

            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 4) / 2), (Console.WindowHeight * 1 / 6) + 12);
            if (focused == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("EXIT");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write("EXIT");
            }

        }

        private void PrintHowToPlay()
        {
            Console.Clear();
            PrintBox();
            PrintHowToPlayText();
        } 

        private void PrintHowToPlayText()
        {
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 2);
            Console.Write("You control the Snake with your ");
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 3);
            Console.Write("Arrwow keys. As it moves forward");
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 4);
            Console.Write("it leaves a trail behind.       ");
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 5);
            Console.Write("The goal is to eat items by     ");
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 6);
            Console.Write("running into them with the head ");
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 7);
            Console.Write("of the snake. Each item eaten   ");
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 8);
            Console.Write("makes the snake longer, so      ");
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 9);
            Console.Write("controlling is progressively    ");
            Console.SetCursorPosition((Console.WindowWidth * 1 / 6) + (((Console.WindowWidth * 4 / 6) - 2 - 32) / 2), (Console.WindowHeight * 1 / 6) + 10);
            Console.Write("more difficult. Good Luck :)    ");
        }

        private void ShowHowToPlay()
        {
            int width = Console.WindowWidth;
            int heigth = Console.WindowHeight;
            ConsoleKeyInfo consoleKeyInfo;

            PrintHowToPlay();
            do
            {
                while (Console.KeyAvailable == false)
                {
                    if (Console.WindowWidth != width || Console.WindowHeight != heigth)
                    {
                        width = Console.WindowWidth;
                        heigth = Console.WindowHeight;
                        PrintHowToPlay();
                    }

                    Thread.Sleep(200);
                }

                consoleKeyInfo = Console.ReadKey(true);
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }
    }
}
