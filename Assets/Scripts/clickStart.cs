using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class clickStart : MonoBehaviour
{
    private Text myText;
    private bool blink = true;

    private void OnEnable()
    {
        myText = GetComponent<Text>();
        StartCoroutine(BlinkText());
    }

    public void ClickDestroy()
    {
        StopCoroutine("BlinkText");
        Destroy(myText, 0.2f);
    }    

    private IEnumerator BlinkText()
    {
        if (myText)
        {
            while (blink)
            {
                myText.CrossFadeAlpha(.3f, 1.2f, true);
                yield return new WaitForSeconds(1.0f);
                myText.CrossFadeAlpha(.9f, .2f, true);
                yield return new WaitForSeconds(.2f);
            }
        }
    }
}
