using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlattform : MonoBehaviour
{
    [Range(0.01f,50)] public float enemyVelocity = 3f;
    public Transform ball;
    private float targetPos;
    private Vector3 newPos;
    private GameManager manager;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        AlterPos();
    }

    private void AlterPos()
    {
        ball = manager.currentBall.transform;
        if (manager.blocks <= 1)
        {
            newPos = rb.position;
            targetPos = ball.position.x;
            newPos.x = Mathf.Lerp(newPos.x, targetPos, enemyVelocity*Time.deltaTime);
            rb.position = newPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Field") { this.transform.Translate(Vector3.zero); }
    }
}
