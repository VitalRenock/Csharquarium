using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public abstract class Fish : Entity
    {
        #region Enums

        public enum FishGender
        {
            Male,
            Female
        }
        public enum HerbivorousFishType
        {
            Sole,
            Bar,
            Carpe
        }
        public enum CarnivorousFishType
        {
            Mérou,
            Thon,
            PoissonClown
        }

        #endregion

        #region Properties

        public string Name { get; set; }
        public FishGender Gender { get; set; }

        #endregion

        #region Constructor

        protected Fish(Position position, char symbol, ConsoleColor color, string name, FishGender gender) : base(position, symbol, color)
        {
            Name = name;
            Gender = gender;
        }

        #endregion
    }
}