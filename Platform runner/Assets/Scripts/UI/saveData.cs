using UnityEngine;
using UnityEngine.UI;

public class saveData : MonoBehaviour
{
    public Dropdown dd;

    public void saveDropDownValue(){
        PlayerPrefs.SetInt("DropDownValue", dd.value);
    }
    public void saveMasterVolumeValue(float volume)
    {
        PlayerPrefs.SetFloat("MasterVolumeValue", volume);
    }
    public void saveMusicVolumeValue(float volume)
    {
        PlayerPrefs.SetFloat("MusikVolumeValue", volume);
    }
    public void saveSoundVolumeValue(float volume)
    {
        PlayerPrefs.SetFloat("SoundVolumeValue", volume);
    }
}
