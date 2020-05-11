using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]

public class SetVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string nameP;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        float val = PlayerPrefs.GetFloat(nameP, 0);
        SetMixer(val);
    }

    public void SetMixer(float volume)
    {
        mixer.SetFloat(nameP, volume);
        slider.value = volume;
        PlayerPrefs.SetFloat(nameP, volume);
    }
}
