using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAchievment : MonoBehaviour {

    public Text deathsText;
    public Text achievmentsText;

	void Start () {
        Display();
	}
	
    void Display()
    {
        var attr = Achievements.instance.saveAttributes;
        deathsText.text = "Lives Lived: " + attr.deaths;
        string completedAchievements = "";
        if(attr.oneHundredDeaths)
        {
            completedAchievements += "One Hundred Deaths, ";
        }

        if(completedAchievements != "")
        {
            completedAchievements =  completedAchievements.Substring(0, completedAchievements.Length - 2);
            achievmentsText.text = "Achievements: " + completedAchievements;
        }
    }
}
