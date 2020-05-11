using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class StateSpeedUp : IState
    {
        #region Singleton State
        private static StateSpeedUp instance = null;
        private StateSpeedUp() { }
        public static StateSpeedUp GetInstance()
        {
            if (instance == null)
            {
                instance = new StateSpeedUp();
            }

            return instance;
        }
        #endregion
    }
}
