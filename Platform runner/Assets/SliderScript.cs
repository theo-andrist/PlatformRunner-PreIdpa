using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    private audioManager aM;
    public Slider slider;

    public bool masterVolume;
    public bool soundVolume;
    public bool musikVolume;

    private void Awake()
    {
        aM = GameObject.FindObjectOfType<audioManager>();

        if (masterVolume)
        {
            slider.value = PlayerPrefs.GetFloat("MasterVolumeValue");
            slider.onValueChanged.AddListener(aM.setMasterVolume);

        }
        else if (musikVolume)
        {
            slider.value = PlayerPrefs.GetFloat("MusikVolumeValue");
            slider.onValueChanged.AddListener(aM.setMusicVolume);
        }
        else if (soundVolume)
        {
            slider.value = PlayerPrefs.GetFloat("SoundVolumeValue");
            slider.onValueChanged.AddListener(aM.setSoundVolume);
        }
    }
}
