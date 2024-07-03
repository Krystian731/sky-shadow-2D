using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{

    public WinLoose winLooseScript;
        void Update()
    {
        if(transform.position.y < -10.0f) 
        {
            winLooseScript.LooseLevel();
        }
    }
}
