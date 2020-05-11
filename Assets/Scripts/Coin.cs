using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager manager = GameManager.instance;

    [SerializeField] private AudioSource audioS;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        audioS.Play();
        manager.AddScore(100);
        Destroy(gameObject, 0.2f);
        }
    }
}
