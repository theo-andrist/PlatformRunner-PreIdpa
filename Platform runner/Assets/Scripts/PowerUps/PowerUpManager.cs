using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    public Text displaytext;

    public float secondsBeforeRemovingText;

    public IEnumerator setDisplayText(string text){

        displaytext.text = text;
        yield return new WaitForSeconds(secondsBeforeRemovingText);
        displaytext.text = "";
    }

}

