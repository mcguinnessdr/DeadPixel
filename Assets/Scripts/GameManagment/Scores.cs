using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour {

    public int deaths = 0;
    public Text deathsText;
    Player player;

	void Start () {
        player = FindObjectOfType<Player>();
        player.died.AddListener(addDeath);
        deathsText.text = "Lives: 0";
	}

    public void addDeath()
    {
        deaths++;
        deathsText.text = "Lives: " + deaths;
    }

}
