using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class StateNormal : IState
    {
        #region Singleton State
        private static StateNormal instance = null;
        private StateNormal() { }
        public static StateNormal GetInstance()
        {
            if (instance == null)
            {
                instance = new StateNormal();
            }

            return instance;
        }

        public void BallState()
        {
            throw new NotImplementedException();
        }

        public void PlattformState()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region State Pattern

        #endregion#
    }
}
