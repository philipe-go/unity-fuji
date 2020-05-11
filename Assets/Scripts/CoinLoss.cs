using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLoss : MonoBehaviour
{
    private GameManager manager = GameManager.instance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.AddScore(-50);
        Destroy(gameObject);
    }
}
