using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SetGraphics : MonoBehaviour
{
    private Slider slide;

    #region Graphics
    [SerializeField] private Text textSets;
    private string[] graphicSets;

    public void Graphics(float set)
    {
        slide.value = set;
        QualitySettings.SetQualityLevel((int)set, true);
        textSets.text = graphicSets[(int)set];
    }
    #endregion

    private void Start()
    {
        graphicSets = QualitySettings.names;
        slide = GetComponent<Slider>();
        float settings = QualitySettings.GetQualityLevel();
        slide.value = settings;
        textSets.text = graphicSets[(int)settings];
    }
}
