using UnityEngine;
using UnityEngine.UI;

public class CheckInputFieldValue : MonoBehaviour
{    
    bool inputCorrect = false;
    int value;

    public void checkInput(string text){
        if(int.TryParse(text, out value)){
            if(value <= 3 || value > 0){
                inputCorrect = true;
            }
        }
        else if (text == "") {
            inputCorrect = true;
        }
    if (!inputCorrect) {
        text = "";
    }
    }
    
}
