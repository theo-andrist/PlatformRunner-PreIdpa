using UnityEngine;
using UnityEngine.UI;

public class AddListenerToEvent : MonoBehaviour
{
    public audioManager aM;
    public Slider slider;

    public bool masterVolume;
    public bool soundVolume;
    public bool musikVolume;

    private void Awake()
    {
        if (masterVolume)
        {
            aM = GameObject.FindObjectOfType<audioManager>();
            slider.onValueChanged.AddListener(aM.setMasterVolume);
        }
        else if (musikVolume)
        {
            aM = GameObject.FindObjectOfType<audioManager>();
            slider.onValueChanged.AddListener(aM.setMusicVolume);
        }
        else if (soundVolume)
        {
            aM = GameObject.FindObjectOfType<audioManager>();
            slider.onValueChanged.AddListener(aM.setSoundVolume);
        }
    }
}
