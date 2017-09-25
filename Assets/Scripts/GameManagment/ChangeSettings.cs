using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSettings : MonoBehaviour {
    public GameManager.Setting setting;

    private void Start()
    {
        GetComponent<Toggle>().isOn = GameManager.instance.GetSetting(setting);
    }
    public void Toggle()
    {
        GameManager.instance.SetSetting(setting, GetComponent<Toggle>().isOn);
    }
}
