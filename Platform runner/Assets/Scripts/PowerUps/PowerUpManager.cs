using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public bool _resetDisplay;

    public Text displaytext;

    private float countdown = 3;

    private void Update()
    {
        if (_resetDisplay )
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            else
            {
                displaytext.text = "";
                _resetDisplay = false;
            }
        }
    }
}

