using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    public Text displaytext;

    public IEnumerator setDisplayText(string text, float duration){

        displaytext.text = text;
        yield return new WaitForSeconds(duration);
        displaytext.text = "";
    }

}

