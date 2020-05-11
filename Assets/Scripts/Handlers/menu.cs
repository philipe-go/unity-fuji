using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] private GameObject[] menuItems;
    [SerializeField] private GameObject clickStart;

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void ActivateOptions()
    {
        bool activeState = menuItems[0].activeSelf;
        menuItems[0].SetActive(!activeState);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ActiveLeaderboard()
    {
        bool activeState = menuItems[1].activeSelf;
        menuItems[1].SetActive(!activeState);
    }

    public void ActiveCredits()
    {
        bool activeState = menuItems[2].activeSelf;
        menuItems[2].SetActive(!activeState);
    }

    public void ClearMenus()
    {
        foreach(GameObject obj in menuItems)
        {
            obj.SetActive(false);
        }
    }
}
