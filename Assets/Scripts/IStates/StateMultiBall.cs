using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class StateMultiBall : IState
    {
        #region Singleton State
        private static StateMultiBall instance = null;
        private StateMultiBall() { }
        public static StateMultiBall GetInstance()
        {
            if (instance == null)
            {
                instance = new StateMultiBall();
            }

            return instance;
        }
        #endregion
    }
}
