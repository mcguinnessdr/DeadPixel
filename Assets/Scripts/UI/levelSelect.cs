using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour {

    public string level;

	void Start () {
        GetComponentInChildren<Text>().text = level;
		if(Achievements.instance.saveAttributes.levelsUnlocked >= LevelManager.instance.levelProgression.levels.IndexOf(level))
        {
            GetComponent<Button>().interactable = true;
        }else
        {
            GetComponent<Button>().interactable = false;

        }
    }

    public void LoadLevel()
    {
        LevelManager.instance.LoadLevel(level);
    }
}
