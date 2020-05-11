using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class StateMegaBall
    {
        #region Singleton State
        private static StateMegaBall instance = null;
        private StateMegaBall() { }
        public static StateMegaBall GetInstance()
        {
            if (instance == null)
            {
                instance = new StateMegaBall();
            }

            return instance;
        }
        #endregion
    }
}
