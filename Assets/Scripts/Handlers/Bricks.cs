using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    private GameManager manager = GameManager.instance;
    public bool canDie;
    public bool isWhite;
    public bool isPurple;
    public bool TopBrick;
    private bool dieWhite;

    //private AudioSource audioS;
    [SerializeField] private AudioSource audioS;

    private void Start()
    {
        dieWhite = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if ((canDie) || (isWhite))
            {
                manager.blocks--;
                Destroy(gameObject, 0.2f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (canDie)
            {
                audioS.Play();
                manager.AddScore(1);
                manager.RemoveBlocks();
                Destroy(gameObject, 0.2f);
            }

            if (isWhite)
            {
                if (dieWhite)
                {
                    audioS.Play();
                    manager.AddScore(10);
                    manager.RemoveBlocks();
                    canDie = false;
                    Destroy(gameObject, 0.2f);
                }
                else
                {
                    dieWhite = true;
                    GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, new Color(146,215,233), Time.deltaTime);
                }
            }

            if (isPurple)
            {
                Debug.Log("LikeWall");
            }

            if (TopBrick)
            {
                if ((manager.startTopBrick) && (manager.blocks <= 1))
                {
                    audioS.Play();
                    manager.AddScore(100);
                    manager.RemoveBlocks();
                    FindObjectOfType<StageHandler>().StageClear();
                    Destroy(gameObject, 0.2f);
                }
            }
        }
    }
}
