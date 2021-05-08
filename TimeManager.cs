using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public static class TimeManager
    {
        #region Properties

        public static int Timer { get; private set; } = 0;

        #endregion

        #region Methods

        // Transformer tick en délégué?
        public static void Tick()
        {
            Timer++;

            WorldManager.MoveFish();
            WorldManager.EatFishs();

            DisplayManager.UpdateDisplay();
        }
        public static void Reset() => Timer = 0;

        #endregion
    }
}
