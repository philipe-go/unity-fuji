using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDown : MonoBehaviour
{
    private GameManager manager = GameManager.instance;
    List<IState> listOfStates;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.AddScore(-10);
        manager.ChangeState(StateMiniPaddle.GetInstance());
        Destroy(gameObject);
    }


}
