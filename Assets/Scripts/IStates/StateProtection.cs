using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class StateProtection : IState
    {
        #region Singleton State
        private static StateProtection instance = null;
        private StateProtection() { }
        public static StateProtection GetInstance()
        {
            if (instance == null)
            {
                instance = new StateProtection();
            }

            return instance;
        }
        #endregion
    }
}
