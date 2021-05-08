using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharquarium
{
    public static class DisplayManager
    {
        #region Properties

        public static Position coordinatesStartPosition { get; } = new Position() { X = 0, Y = 0 };
        public static Position worldStartPosition { get; } = new Position() { X = 2, Y = 1 };
        public static Position menuStartPosition { get; } = new Position() { X = 0, Y = 30 };
        public static Position fishsListStartPosition { get; } = new Position() { X = 30, Y = 0 };
        public static Position messageStartPosition { get; } = new Position() { X = 0, Y = 40 };

        #endregion

        #region Methods

        public static void DisplayWorld(Position worldStartPosition, Entity[,] entities)
        {
            for (int x = entities.GetLength(0) - 1; x >= 0; x--)
            {
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.Write(x + "\t");
                for (int y = entities.GetLength(1) - 1; y >= 0; y--)
                {
                    Console.SetCursorPosition(worldStartPosition.X + x, worldStartPosition.Y + y);
                    if (entities[x, y] != null)
                    {
                        Console.ForegroundColor = entities[x, y].Color;
                        Console.Write(entities[x, y].Symbol);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("░");
                    }
                }
            }

            #region Obsolète

            //Console.WriteLine(" \t43210");
            //for (int x = entities.GetLength(0) - 1; x >= 0; x--)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.Write(x + "\t");
            //    for (int y = entities.GetLength(1) - 1; y >= 0; y--)
            //    {
            //        if (entities[x, y] != null)
            //        {
            //            Console.ForegroundColor = entities[x, y].Color;
            //            Console.Write(entities[x, y].Symbol);
            //        }
            //        else
            //        {
            //            Console.ForegroundColor = ConsoleColor.Blue;
            //            Console.Write("░");
            //        }
            //    }
            //    Console.WriteLine();
            //}



            //Console.WriteLine(" \t01234567890123456789");
            //for (int x = 0; x < entities.GetLength(0); x++)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.Write(x + "\t");
            //    for (int y = 0; y < entities.GetLength(1); y++)
            //    {
            //        if (entities[x,y] != null)
            //        {
            //            Console.ForegroundColor = entities[x, y].Color;
            //            Console.Write(entities[x,y].Symbol);
            //        }
            //        else
            //        {
            //            Console.ForegroundColor = ConsoleColor.Blue;
            //            Console.Write("░");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            #endregion
        }
        public static void DisplayMenu(Position startPosition)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(startPosition.X, startPosition.Y);
            Console.Write("Que voulez-vous faire?");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + 1);
            Console.Write("0 = Tour suivant");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + 2);
            Console.Write("9 = Exit");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + 3);
        }
        public static void DisplayCoordinates(Position startPosition, Entity[,] entities)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int x = 1; x <= entities.GetLength(0); x++)
            {
                Console.SetCursorPosition(startPosition.X + x + 1, 0);
                Console.Write(x);
            }
            for (int y = 1; y <= entities.GetLength(1); y++)
            {
                Console.SetCursorPosition(0, startPosition.Y + y);
                Console.Write(y);
            }
        }
        public static void DisplayFishsList(Position startPostion, Entity[,] entities)
        {
            ClearPartialDisplay(startPostion, 50, Console.LargestWindowHeight);

            int lineNumber = 0;
            foreach (Entity entity in entities)
            {
                if (entity is Fish)
                {
                    if (entity is FishCarnivorous)
                    {
                        DisplayFish(startPostion, ref lineNumber, entity as FishCarnivorous);
                    }
                    else if (entity is FishHerbivorous)
                    {
                        DisplayFish(startPostion, ref lineNumber, entity as FishHerbivorous);
                    }
                    else
                    {
                        // Error
                    }
                }
            }
        }
        static void DisplayFish(Position startPosition, ref int lineNumber, FishCarnivorous fish)
        {
            Console.ForegroundColor = fish.Color;

            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("Nom: " + fish.Name);
            lineNumber++;
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("Espèce: " + fish.Type.ToString());
            lineNumber++;
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("Sexe: " + fish.Gender.ToString());
            lineNumber++;
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("Régime: " + fish.GetType().ToString());
            lineNumber++;
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("Position: x=" + fish.Position.X + " y = " + fish.Position.Y);
            lineNumber++;
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("►" + fish.ForwardObstructed);
            lineNumber++;
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("---------------");
            lineNumber++;
        }
        static void DisplayFish(Position startPosition, ref int lineNumber, FishHerbivorous fish)
        {
            Console.ForegroundColor = fish.Color;

            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("Nom: " + fish.Name);
            lineNumber++;
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("Espèce: " + fish.Type.ToString());
            lineNumber++;
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("Sexe: " + fish.Gender.ToString());
            lineNumber++;
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("Régime: " + fish.GetType().ToString());
            lineNumber++;
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("Position: x=" + fish.Position.X + " y = " + fish.Position.Y);
            lineNumber++;
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y + lineNumber);
            Console.Write("---------------");
            lineNumber++;
        }
        public static void DisplayMessage(Position startPosition, string message) 
        {
            Console.SetCursorPosition(startPosition.X, startPosition.Y);
            Console.Write("                                            ");
            Console.SetCursorPosition(startPosition.X, startPosition.Y);
            Console.Write(message);
        }
        public static void UpdateDisplay()
        {
            //ClearDisplay();
            //DisplayCoordinates(coordinatesStartPosition, WorldManager.entities);
            DisplayWorld(worldStartPosition, WorldManager.entities);
            DisplayMenu(menuStartPosition);
            //DisplayFishsList(fishsListStartPosition, WorldManager.entities);
        }

        public static void ClearDisplay()
        {
            for (int x = 0; x < Console.LargestWindowWidth; x++)
                for (int y = 0; y < Console.LargestWindowHeight; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
        }
        public static void ClearPartialDisplay(Position startPosition, int xLenght, int yLenght)
        {
            for (int x = startPosition.X; x < startPosition.X + xLenght; x++)
            {
                for (int y = startPosition.Y; y < startPosition.Y + yLenght; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
            }
        }

        public static void InitDisplay()
        {
            // Setup console window
            CenterConsole();
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            //Console.Clear();
            
            // Intro
            Console.WriteLine("Loading NASA.Simulation.Aquarium...");
            Thread.Sleep(100);
            Console.Clear();

            // Display application
            UpdateDisplay();
            DisplayFishsList(fishsListStartPosition, WorldManager.entities);
        }

        #endregion

        #region Imported code

        public static void CenterConsole()
        {
            var consoleWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            Imports.SetWindowPos(consoleWnd, 0, -10, 40, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);
        }

        static class Imports
        {
            public static IntPtr HWND_BOTTOM = (IntPtr)1;
            //public static IntPtr HWND_NOTOPMOST = (IntPtr) - 2;
            public static IntPtr HWND_TOP = (IntPtr)0;
            //public static IntPtr HWND_TOPMOST = (IntPtr) - 1;

            public static uint SWP_NOSIZE = 0;
            public static uint SWP_NOZORDER = 4;

            [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
            public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint wFlags);
        }

        #endregion
    }
}