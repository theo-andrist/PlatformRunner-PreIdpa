using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    public Text displaytext;

    public IEnumerator setDisplayText(string text, float duration){
        Debug.Log("Display set");
        displaytext.text = text;
        yield return new WaitForSeconds(duration);
        displaytext.text = "";
        Debug.Log("Display removed");
    }

}

