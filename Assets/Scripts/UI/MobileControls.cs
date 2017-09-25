using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour {

    public List<Transform> controls;

    void Start () {
        if (!GameManager.instance.mobileControls)
        {
            foreach (var control in controls)
            {
                control.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach(var control in controls)
            {
                control.gameObject.SetActive(true);
            }
        }

    }
}
