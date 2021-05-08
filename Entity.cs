using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public abstract class Entity
    {
        #region Properties

        public Position Position { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        #endregion

        #region Constructor

        protected Entity(Position position, char symbol, ConsoleColor color)
        {
            Position = position;
            Symbol = symbol;
            Color = color;
        }

        #endregion

        #region Shortcuts

        public bool ForwardObstructed
        {
            get
            {
                if (Position.X < WorldManager.entities.GetLength(0) - 1)
                    return WorldManager.entities[Position.X + 1, Position.Y] != null ? true : false;
                else
                    return false;
            }
        }
        public bool BackwardObstructed
        {
            get
            {
                if (Position.X > 0)
                    return WorldManager.entities[Position.X - 1, Position.Y] != null ? true : false;
                else
                    return false;
            }
        }
        public bool UpwardObstructed
        {
            get
            {
                if (Position.Y < WorldManager.entities.GetLength(1) - 1)
                    return WorldManager.entities[Position.X, Position.Y + 1] != null ? true : false;
                else
                    return false;
            }
        }
        public bool DownwardObstructed
        {
            get
            {
                if (Position.Y > 0)
                    return WorldManager.entities[Position.X, Position.Y - 1] != null ? true : false;
                else
                    return false;
            }
        }
        public bool ProximityAlert { get => (ForwardObstructed || BackwardObstructed || UpwardObstructed || DownwardObstructed) == true ? true : false; }

        #endregion

        #region Methods

        public void MoveEntity(Direction direction)
        {
            Entity[,] entities = WorldManager.entities;

            switch (direction)
            {
                case Direction.Forward:
                    if (Position.X < WorldManager.entities.GetLength(0) - 1)
                        if (!ForwardObstructed)
                        {
                            Position oldPosition = new Position() { X = Position.X, Y = Position.Y };
                            Position.Forward();

                            entities[Position.X, Position.Y] = this;
                            entities[oldPosition.X, oldPosition.Y] = null;
                        }
                    break;
                case Direction.Backward:
                    if (Position.X > 0)
                        if (!BackwardObstructed)
                        {
                            Position oldPosition = new Position() { X = Position.X, Y = Position.Y };
                            Position.Backward();

                            entities[Position.X, Position.Y] = this;
                            entities[oldPosition.X, oldPosition.Y] = null;
                        }
                    break;
                case Direction.Upward:
                    if (Position.Y < WorldManager.entities.GetLength(1) - 1)
                        if (!UpwardObstructed)
                        {
                            Position oldPosition = new Position() { X = Position.X, Y = Position.Y };
                            Position.Upward();

                            entities[Position.X, Position.Y] = this;
                            entities[oldPosition.X, oldPosition.Y] = null;
                        }
                    break;
                case Direction.Downward:
                    if (Position.Y > 0)
                        if (!DownwardObstructed)
                        {
                            Position oldPosition = new Position() { X = Position.X, Y = Position.Y };
                            Position.Downward();

                            entities[Position.X, Position.Y] = this;
                            entities[oldPosition.X, oldPosition.Y] = null;
                        }
                    break;
                default:
                    // Error
                    break;
            }
        }
        public List<Entity> FindEntities()
        {
            List<Entity> neighbours = new List<Entity>();

            if (ForwardObstructed)
            {
                Entity target = WorldManager.entities[Position.X + 1, Position.Y];
                if (target is Fish)
                    neighbours.Add(target);
            }
            if (BackwardObstructed)
            {
                Entity target = WorldManager.entities[Position.X - 1, Position.Y];
                if (target is Fish)
                    neighbours.Add(target);
            }
            if (UpwardObstructed)
            {
                Entity target = WorldManager.entities[Position.X, Position.Y + 1];
                if (target is Fish)
                    neighbours.Add(target);
            }
            if (DownwardObstructed)
            {
                Entity target = WorldManager.entities[Position.X, Position.Y - 1];
                if (target is Fish)
                    neighbours.Add(target);
            }
            return neighbours;
        }
        public bool FindEntity(out Entity finded)
        {
            if (ForwardObstructed)
            {
                finded = WorldManager.entities[Position.X + 1, Position.Y];
                return true;
            }
            else if (BackwardObstructed)
            {
                finded = WorldManager.entities[Position.X - 1, Position.Y];
                return true;
            }
            else if (UpwardObstructed)
            {
                finded = WorldManager.entities[Position.X, Position.Y + 1];
                return true;
            }
            else if (DownwardObstructed)
            {
                finded = WorldManager.entities[Position.X, Position.Y - 1];
                return true;
            }
            else
            {
                finded = null;
                return false;
            }
        }

        #endregion
    }
}