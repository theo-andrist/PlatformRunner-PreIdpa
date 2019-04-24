using UnityEngine;
using UnityEngine.UI;

public class saveData : MonoBehaviour
{
    public Dropdown dd;

    public void saveDropDownValue(){
        PlayerPrefs.SetInt("DropDownValue", dd.value);
    }
}
