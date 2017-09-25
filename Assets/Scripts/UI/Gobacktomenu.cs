using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gobacktomenu : MonoBehaviour {

    float ButtonCount;
    public bool returnAuto = false;

	void Start () {
        if(returnAuto)
        {
            Invoke("Return", 5f);
        }
	}

    void Return()
    {
        print("returning");
        SceneManager.LoadScene("Menu");
    }
}
