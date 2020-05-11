using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public struct player
{
    public string name;
    public int score;
}

public class GameManager : MonoBehaviour
{
    #region GameManager Attributes
    [Header("Stages")]
    [SerializeField] private GameObject[] stages;
    public GameObject currentBall;
    public GameObject currentStage;

    [Header("Character")]
    [SerializeField] private GameObject[] character;

    [Header("Canvas Items")]
    [SerializeField] private GameObject paused;
    [SerializeField] private GameObject clickStart;
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject menu;
    [SerializeField] private menu subMenus;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject replayStage;
    [SerializeField] private GameObject endGame;

    [Header("User Interface")]
    [SerializeField] private Text stageTxt;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private InputField nameField;
    [SerializeField] private Text scoreFinal;

    [Header("Life Manager")]
    [SerializeField] private GameObject[] lifesObj;

    [Header("Background Objects")]
    [SerializeField] private GameObject fog;
    [SerializeField] private GameObject flyingLight;

    [Header("Main Camera")]
    [SerializeField] private CameraHandler mainCam;
    #endregion

    #region SingletonPattern
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    #endregion

    #region GameHandler
    internal bool gameStarted;
    internal float lives;
    private int score;
    internal bool pause;
    private int bestScore;

    internal bool startEnemy;
    internal bool startTopBrick;
    public int blocks;
    public Player currentPlayer;
    public player play = new player();
    #endregion

    #region StagesHandler
    internal int currentLevel;
    internal bool loadNewLevel;
    private bool loadCanvas;
    #endregion

    private void Start()
    {
        score = 0;
        lives = 3f;
        currentLevel = 0;
        blocks = 0;

        loadNewLevel = false;
        loadCanvas = true;
        gameStarted = false;

        play.name = "guest";
        play.score = score;
        scoreTxt.text = $"score = {score.ToString("D6")}";
    }

    void Update()
    {
        PauseGame();

        if (blocks <= 1)
        {
            if (currentLevel == 4) startEnemy = true;
            startTopBrick = true;
        }
    }

    public void OpenMenu()
    {
        Time.timeScale = 1 - Time.timeScale;
        if (!gameStarted)
        {
            clickStart.SetActive(!clickStart.activeSelf);
            flyingLight.SetActive(!flyingLight.activeSelf);
        }
        else
        {
            if (currentStage)
            {
                currentStage.SetActive(!currentStage.activeSelf);
                if (!currentBall.activeSelf) currentBall.GetComponent<BallCharacter>().InitializeBall();
                currentBall.SetActive(!currentBall.activeSelf);
            }
            else
            {
                menu.SetActive(!menu.activeSelf);
                Time.timeScale = 1 - Time.timeScale;
            }
        }
        subMenus.ClearMenus();
        menu.SetActive(!menu.activeSelf);
    }

    internal void ChangeState(IState aState)
    {
        //currentPlayer.currentState = aState;
    }

    //public void LoadNextLevel()
    //{
    //    if (currentLevel < 5)
    //    {
    //        SceneManager.LoadSceneAsync((currentLevel + 2), LoadSceneMode.Additive);
    //        if (currentLevel > 0) { SceneManager.UnloadSceneAsync(currentLevel + 1); }
    //        stageCanvas[0].GetComponent<Text>().text = $"Stage: {currentLevel}";
    //    }
    //    else
    //    {
    //        currentLevel = 4;

    //        SceneManager.LoadSceneAsync((currentLevel + 2), LoadSceneMode.Additive);
    //        stageCanvas[0].GetComponent<Text>().text = $"Stage: {currentLevel}";
    //    }

    //    System.GC.Collect();

    //    if (currentLevel == 2) { camAnimStages.SetBool("2ndStage", true); }
    //    if (currentLevel == 3) { camAnimStages.SetBool("3rdStage", true); }
    //    if (currentLevel == 4) { camAnimStages.SetBool("4thStage", true); }

    //    currentLevel++;

    //    startEnemy = false;
    //    startTopBrick = false;
    //    loadNewLevel = false;
    //    destroyAll = false;
    //}

    //private void LoadCanvas()
    //{
    //    if (gameCanvas.Length != 0)
    //    {
    //        for (int i = 0; i < gameCanvas.Length; i++)
    //        {
    //            gameCanvas[i].SetActive(true);
    //            stageCanvas[0].GetComponent<Text>().text = $"Stage: {currentLevel + 1}";
    //        }
    //    }

    //    loadCanvas = false;
    //    loadNewLevel = true;
    //}


    public void AddScore(int aScore)
    {
        score += aScore;

        scoreTxt.text = $"score = {score.ToString("D6")}";
    }

    public void AddBlocks()
    {
        blocks++;
    }

    public void RemoveBlocks()
    {
        blocks--;
    }

    public void LifesHandler()
    {
        this.lives--;

        switch (this.lives)
        {
            case (1):
                {
                    lifesObj[0].SetActive(false);
                    lifesObj[1].SetActive(false);
                    lifesObj[2].SetActive(true);
                }
                break;
            case (2):
                {

                    lifesObj[0].SetActive(false);
                    lifesObj[1].SetActive(true);
                    lifesObj[2].SetActive(true);
                }
                break;
            case (3):
                {
                    lifesObj[0].SetActive(true);
                    lifesObj[1].SetActive(true);
                    lifesObj[2].SetActive(true);
                }
                break;
            case (0):
                {
                    lifesObj[0].SetActive(false);
                    lifesObj[1].SetActive(false);
                    lifesObj[2].SetActive(false);
                    gameOver.SetActive(true);
                    replayStage.SetActive(true);
                    Time.timeScale = 0;
                }
                break;
        }
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused.SetActive(!paused.activeSelf);
            Time.timeScale = 1 - Time.timeScale;
        }
    }

    public void ReloadStage()
    {
        gameOver.SetActive(false);
        replayStage.SetActive(false);
        Time.timeScale = 1f;
        score = 0;
        lives = 4;
        scoreTxt.text = $"score = {score.ToString("D6")}";
        LifesHandler();
        Destroy(GameObject.FindGameObjectWithTag("Stage"));
        LoadStage();
    }

    private void NextStage()
    {
        currentLevel++;
    }

    internal void LoadStage()
    {
        if (gameStarted)
        {
            if (currentLevel > 4)
            {
                endGame.SetActive(true);
                scoreFinal.text = score.ToString("D6");
            }
            else
            {
                if (currentBall) Destroy(currentBall.gameObject);
                Instantiate(stages[currentLevel - 1]);
                stageTxt.text = $"Stage: {currentLevel}";
                board.SetActive(true);
                fog.SetActive(true);
            }
        }
    }

    public void StartStage()
    {
        gameStarted = true;
        mainCam.ChangePos();
        currentLevel = 1;
    }

    public void AddName()
    {
        play.name = nameField.onValueChanged.ToString();
        play.score = System.Convert.ToInt32(scoreFinal);
    }
}
