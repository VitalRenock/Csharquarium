using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharquarium
{
    public static class WorldManager
    {
        public static Entity[,] entities = new Entity[10, 10];
        static Random random = new Random();

        public static void AddEntity(Entity entityToAdd)
        {
            if (entityToAdd == null)
                return;

            foreach (Entity entity in entities)
            {
                if (entity != null && entityToAdd.Position.X == entity.Position.X && entityToAdd.Position.Y == entity.Position.Y)
                    return;
            }

            entities[entityToAdd.Position.X, entityToAdd.Position.Y] = entityToAdd;
        }
        public static void RemoveEntity(Entity entityToRemove)
        {
            if (entityToRemove == null)
                return;

            entities[entityToRemove.Position.X, entityToRemove.Position.Y] = null;
        }
        public static Entity CreateRandomEntity()
        {
            // For choose a ramdom type of entity
            int randomEntity = random.Next(0, 3);

            // Find an empty random position in entities
            Position randomPosition = null;
            while (randomPosition == null)
            {
                int xRandom = random.Next(0, entities.GetLength(0) - 1);
                int yRandom = random.Next(0, entities.GetLength(1) - 1);
                if (entities[xRandom, yRandom] == null)
                    randomPosition = new Position() { X = xRandom, Y = yRandom };
            }

            int randomType = random.Next(0, 3);
            int randomGender = random.Next(0, 2);

            switch (randomEntity)
            {
                case 0:
                    return new Algae(randomPosition, 'a', ConsoleColor.Green);
                case 1:
                    return new FishHerbivorous
                        (randomPosition, 'h', ConsoleColor.Yellow, DateTime.Now.ToShortTimeString(), (Fish.FishGender)randomGender, (Fish.HerbivorousFishType)randomType);
                case 2:
                    return new FishCarnivorous
                        (randomPosition, 'c', ConsoleColor.Red, DateTime.Now.ToShortTimeString(), (Fish.FishGender)randomGender, (Fish.CarnivorousFishType)randomType);
                default:
                    return new Algae(randomPosition, 'd', ConsoleColor.Green);
            }
        }
        public static bool FindEmptyPosition(out Position emptyPosition)
        {
            for (int x = 0; x < entities.GetLength(0) - 1; x++)
                for (int y = 0; y < entities.GetLength(1) - 1; y++)
                    if (entities[x, y] == null)
                    {
                        emptyPosition = new Position();
                        emptyPosition.X = x;
                        emptyPosition.Y = y;
                        return true;
                    }
            
            emptyPosition = null;
            return false;
        }

        public static void MoveFish()
        {
            List<Fish> movedFish = new List<Fish>();

            for (int x = entities.GetLength(0) - 1; x >= 0; x--)
            {
                for (int y = entities.GetLength(1) - 1; y >= 0 ; y--)
                {
                    if (entities[x, y] is Fish && !movedFish.Contains((Fish)entities[x, y]))
                    {
                        movedFish.Add(entities[x, y] as Fish);

                        int randomNumber = random.Next(Enum.GetValues(typeof(Direction)).Length);
                        entities[x, y].MoveEntity((Direction)randomNumber);
                    }
                }
            }
        }
        public static void EatFishs()
        {
            for (int x = entities.GetLength(0) - 1; x >= 0; x--)
                for (int y = entities.GetLength(1) - 1; y >= 0; y--)
                    if (entities[x, y] is FishCarnivorous)
                    {
                        FishCarnivorous hunter = entities[x, y] as FishCarnivorous;
                        Entity target;
                        if (hunter.FindEntity(out target))
                            if (target is Fish)
                            {
                                hunter.Manger(target as Fish);
                                RemoveEntity(target);
                                DisplayManager.DisplayFishsList(DisplayManager.fishsListStartPosition, entities);
                            }
                    }
        }
    }
}
