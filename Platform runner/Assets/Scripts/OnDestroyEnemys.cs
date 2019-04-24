using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyEnemys : MonoBehaviour
{
    public static int killcount = 0;

    void OnDestroy() {
        killcount++;
    }
}
