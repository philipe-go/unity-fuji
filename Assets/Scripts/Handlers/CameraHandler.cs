using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform[] cameraPlaceHolders;
    [Range(0.01f, 0.9f)] public float cameraSpeed = 0.03f;
    private float temp;
    private GameManager gm;
    private bool doOnce;
    private bool change;

    private void Start()
    {
        change = false;
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (change)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, cameraPlaceHolders[gm.currentLevel].position, cameraSpeed);
            if (transform.position == cameraPlaceHolders[gm.currentLevel].position) { gm.LoadStage(); change = false; }
        }
    }

    public void ChangePos()
    {
        change = true;
    }
}
