using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeGame : MonoBehaviour {

    public void Resume()
    {
        GameManager.instance.pause.Unpause();
    }
}
