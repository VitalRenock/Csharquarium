using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class FishHerbivorous : Fish
    {
        #region Properties
        
        public HerbivorousFishType Type { get; set; }

        #endregion

        #region Constructor
        
        public FishHerbivorous(Position position, char symbol, ConsoleColor color, string name, FishGender gender, HerbivorousFishType type) : base(position, symbol, color, name, gender)
        {
            Type = type;
        }

        #endregion
        
        #region Methods
        
        public void Manger(Algae algae)
        {
        } 

        #endregion
    }
}
