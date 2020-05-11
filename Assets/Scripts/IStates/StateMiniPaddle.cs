using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class StateMiniPaddle : PaddleCharacter, IState
    {
        #region Singleton State
        private static StateMiniPaddle instance = null;
        private StateMiniPaddle() : base()
        {
        }
        
        public static StateMiniPaddle GetInstance()
        {
            if (instance == null)
            {
                instance = new StateMiniPaddle();
            }

            return instance;
        }

        public void ChangeStateClass()
        {
            base.transform.localScale += new Vector3(1, 0, 0);
        }
        #endregion
    }
}
