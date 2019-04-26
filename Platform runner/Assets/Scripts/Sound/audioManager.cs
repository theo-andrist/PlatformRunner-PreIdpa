using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static audioManager instance;
    public AudioMixer mainMixer;
    public GameObject AudioPanel;

    void Awake(){

        if(instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;

            s.source.spatialBlend = s.spatialBlend;
            s.source.outputAudioMixerGroup = s.output;
        }
    }
    void Start()
    {
        Play("Theme");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s==null){
            Debug.Log(s.name +"gibt es nicht");
            return;
        }
        s.source.Play();
    }
    public void setMasterVolume(float volume){
        
        mainMixer.SetFloat("Master", volume);        
    }
    public void setSoundVolume(float volume){
        
        mainMixer.SetFloat("Sound", volume);        
    }
    public void setMusicVolume(float volume){
        
        mainMixer.SetFloat("Music", volume);        
    }
}
