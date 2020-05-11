using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] blocks;
    [SerializeField] private GameObject ball;
    public int totalBlocks = 0;
    private GameManager gm;

    private void Start()
    {
        StartStage();
    }

    public void StartStage()
    {
        gm = FindObjectOfType<GameManager>();
        gm.currentStage = this.gameObject;
        Instantiate(ball);
        transform.position = new Vector3(512, 384, 0);
        foreach (GameObject obj in blocks)
        {
            totalBlocks++;
        }
        gm.blocks = totalBlocks;
    }

    public void StageClear()
    {
        FindObjectOfType<CameraHandler>().ChangePos();
        gm.currentLevel++;
        //Destroy(ball);
        Destroy(this.gameObject);
    }
}
