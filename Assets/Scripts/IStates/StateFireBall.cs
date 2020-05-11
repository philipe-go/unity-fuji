using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class StateFireBall : IState
    {
        #region Singleton State
        private static StateFireBall instance = null;
        private StateFireBall() { }
        public static StateFireBall GetInstance()
        {
            if (instance == null)
            {
                instance = new StateFireBall();
            }

            return instance;
        }
        #endregion


    }
}
