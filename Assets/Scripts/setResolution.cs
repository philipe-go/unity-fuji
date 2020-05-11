using UnityEngine;
using UnityEngine.UI;

public class setResolution : MonoBehaviour
{
    private Toggle myToggle;
    private Dropdown myResolution;

    void Start()
    {
        #region FullScreen
        myToggle = GetComponent<Toggle>();
        #endregion

        #region Resolution
        myResolution = GetComponent<Dropdown>();
        int currentResWidth = Screen.currentResolution.width;
        int currentResHeight = Screen.currentResolution.height;
        #endregion
    }

    public void SetFullScreen()
    {
        bool setRes = myToggle.isOn;
        Screen.fullScreen = setRes;

        Debug.Log($"Fullscreen Mode: {Screen.fullScreenMode}");
    }

    public void SetScreenResolution()
    {
        switch (myResolution.itemText.text)
        {
            case ("Option A"):
                {
                    Screen.SetResolution(600, 450, true);
                }
                break;
            case ("Option B"):
                {
                    Screen.SetResolution(800, 600, true);
                }
                break;
            case ("Option C"):
                {
                    Screen.SetResolution(1024, 768, true);
                }
                break;
            default:
                {
                    Screen.SetResolution(1024, 768, true);
                }
                break;
        }
        Debug.Log($"Resolution: {Screen.currentResolution}");
    }
}
