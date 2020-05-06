using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using System.Collections;

public class loading : MonoBehaviour
{
    private AsyncOperation async;
    private float waitTime = 10.0f;
    [SerializeField] private Image progressBar;
    [SerializeField] private Text progressText;


    private void Start()
    {
        Time.timeScale = 1;
        Input.ResetInputAxes();

        Scene currentScene = SceneManager.GetActiveScene();
        async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
        async.allowSceneActivation = false;
        System.GC.Collect();
    }

    private void Update()
    {
        if (progressBar)
        {
            progressBar.fillAmount = async.progress + 0.1f;
        }

        if (progressText)
        {
            progressText.text = ((async.progress + 0.1f) * 100).ToString("f1") + " %";
        }

        if ((async.progress > 0.89f))
        {
            if (SplashScreen.isFinished) { async.allowSceneActivation = true; }
        }
    }

    private YieldInstruction SplashScreenPause()
    {
        return new WaitForSeconds(waitTime);
    }
}
