using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameManager manager = GameManager.instance;

    Random random = new Random();

    [SerializeField] private AudioSource audioS;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioS.Play();
            manager.AddScore(10);
            manager.ChangeState(StateMegaPaddle.GetInstance());
            Destroy(gameObject, 0.1f);

        }
    }
}
