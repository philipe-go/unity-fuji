using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class StateMegaPaddle : IState
    {
        #region Singleton State
        private static StateMegaPaddle instance = null;
        private StateMegaPaddle() { }
        public static StateMegaPaddle GetInstance()
        {
            if (instance == null)
            {
                instance = new StateMegaPaddle();
            }

            return instance;
        }
        #endregion
    }
}
