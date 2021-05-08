using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
                WorldManager.AddEntity(WorldManager.CreateRandomEntity());

            //FishHerbivorous fishHerbivorous1 = new FishHerbivorous(new Position() { X = 0, Y = 5 }, '☼', ConsoleColor.DarkYellow, "Herbi", Fish.FishGender.Female, Fish.HerbivorousFishType.Bar);
            //WorldManager.AddEntity(fishHerbivorous1);
            //FishHerbivorous fishHerbivorous2 = new FishHerbivorous(new Position() { X = 1, Y = 4 }, '☼', ConsoleColor.DarkYellow, "Herbi", Fish.FishGender.Female, Fish.HerbivorousFishType.Bar);
            //WorldManager.AddEntity(fishHerbivorous2);
            //FishHerbivorous fishHerbivorous3 = new FishHerbivorous(new Position() { X = 2, Y = 3 }, '☼', ConsoleColor.DarkYellow, "Herbi", Fish.FishGender.Female, Fish.HerbivorousFishType.Bar);
            //WorldManager.AddEntity(fishHerbivorous3);
            //FishHerbivorous fishHerbivorous4 = new FishHerbivorous(new Position() { X = 3, Y = 2 }, '☼', ConsoleColor.DarkYellow, "Herbi", Fish.FishGender.Female, Fish.HerbivorousFishType.Bar);
            //WorldManager.AddEntity(fishHerbivorous4);

            //FishCarnivorous fishCarnivorous1 = new FishCarnivorous(new Position() { X = 0, Y = 3 }, '☼', ConsoleColor.DarkRed, "Carni", Fish.FishGender.Male, Fish.CarnivorousFishType.Mérou);
            //WorldManager.AddEntity(fishCarnivorous1);
            //FishCarnivorous fishCarnivorous2 = new FishCarnivorous(new Position() { X = 9, Y = 9 }, '☼', ConsoleColor.DarkRed, "Carni", Fish.FishGender.Male, Fish.CarnivorousFishType.Mérou);
            //WorldManager.AddEntity(fishCarnivorous2);

            //Algae algae = new Algae(new Position() { X = 2, Y = 2 }, 'a', ConsoleColor.DarkGreen);
            //WorldManager.AddEntity(algae);


            StartSimulation();

            #region Manual mode

            //string inputUser = string.Empty;
            //while (inputUser != "9")
            //{
            //    inputUser = Console.ReadLine();
            //    if (inputUser == "0")
            //    {
            //        TimeManager.Tick();
            //    }
            //}

            #endregion

            #region Automatic mode

            while (TimeManager.Timer <= 10000)
            {
                TimeManager.Tick();
                Thread.Sleep(800);
            }

            #endregion

            EndSimulation();
        }

        static void StartSimulation()
        {
            DisplayManager.InitDisplay();

        }
        static void EndSimulation()
        {
            Console.Clear();
            Console.WriteLine("That's all folks");
            Thread.Sleep(1500);
            //Console.ReadLine();
        }
    }
}
