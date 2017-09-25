using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour {

    public static LevelSettings instance;
    public bool Pausable;

    private void Awake()
    {
        instance = this;
    }
}
