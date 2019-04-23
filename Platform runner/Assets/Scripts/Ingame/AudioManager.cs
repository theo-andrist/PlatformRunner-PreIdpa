using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioMixer Mixer;

    public static AudioManager audioInstance;

    public GameObject AudioPanel;

    public Slider gesamtSlider;
    public Slider musikSlider;
    public Slider soundSlider;

    private void Awake()
    {
        if (audioInstance == null)
        {
            audioInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        DontDestroyOnLoad(gameObject);

        AudioPanel = GameObject.Find("Canvas/AudioPanel");
        AudioPanel.SetActive(false);

        gesamtSlider = AudioPanel.transform.GetChild(2).GetComponent<Slider>();
        musikSlider = AudioPanel.transform.GetChild(4).GetComponent<Slider>();
        soundSlider = AudioPanel.transform.GetChild(6).GetComponent<Slider>();

        gesamtSlider.onValueChanged.AddListener(setVolumeGesamt);
        musikSlider.onValueChanged.AddListener(setVolumeMusik);
        soundSlider.onValueChanged.AddListener(setVolumeSound);
    }

    public void setVolumeGesamt(float volume)
    {
        Mixer.SetFloat("GesamtVolume", volume);
    }

    public void setVolumeMusik(float volume)
    {
        Mixer.SetFloat("MusikVolume", volume);
    }

    public void setVolumeSound(float volume)
    {
        Mixer.SetFloat("SoundVolume", volume);
    }
}
