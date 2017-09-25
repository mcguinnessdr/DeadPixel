using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableHudOnPause : MonoBehaviour {

    private void OnEnable()
    {
        GameManager.instance.pause.OnPause.AddListener(DisableHUD);
        GameManager.instance.pause.OnUnpause.AddListener(EnableHUD);
    }

    private void OnDisable()
    {
        GameManager.instance.pause.OnPause.RemoveListener(DisableHUD);
        GameManager.instance.pause.OnUnpause.RemoveListener(EnableHUD);
    }

    void DisableHUD()
    {
        GetComponent<GraphicRaycaster>().enabled = false;
    }

    void EnableHUD()
    {
        GetComponent<GraphicRaycaster>().enabled = true;
    }
}
