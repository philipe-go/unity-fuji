using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Player : MonoBehaviour
{
    #region Player Attributes
    internal string playerName;
    internal IState currentState;

    internal float ballRadius;
    internal float softness;
    internal float paddleSize;
    internal float numberOfBalls;
    internal float speed;
    internal bool glue;
    #endregion

    public Player(string name)
    {
        this.playerName = name;
        this.currentState = StateNormal.GetInstance();
    }
}
