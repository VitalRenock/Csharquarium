using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class FishCarnivorous : Fish
    {
        #region Properties

        public CarnivorousFishType Type { get; set; }

        #endregion

        #region Constructor

        public FishCarnivorous(Position position, char symbol, ConsoleColor color, string name, FishGender gender, CarnivorousFishType type) : base(position, symbol, color, name, gender)
        {
            Type = type;
        }

        #endregion
        
        #region Methods

        public void Manger(Fish fish)
        {
            List<Entity> targets = FindEntities();

            if (targets.Count > 0)
            {
                for (int i = 0; i < targets.Count; i++)
                {
                    if (targets[i] is Fish)
                    {
                        
                        DisplayManager.DisplayMessage(DisplayManager.messageStartPosition, this.Name + " à mangé " + (targets[i] as Fish).Name);
                    }
                }
            }
        }

        #endregion
    }
}