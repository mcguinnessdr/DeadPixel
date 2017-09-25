using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_ANDROID
using UnityEngine.Advertisements;
#endif

public class LevelManager : Singleton<LevelManager> {

    public LevelProgression levelProgression;
    public int adLastShown;

    public void LoadNextLevel()
    {
        var currentIndex = levelProgression.levels.IndexOf(SceneManager.GetActiveScene().name);
        print(currentIndex);
        print(levelProgression.levels.Count);
        if (currentIndex == levelProgression.levels.Count - 1)
        {
            LoadLevel("Win");
        }
        else
        {
            Achievements.instance.saveAttributes.levelsUnlocked = currentIndex + 1 > Achievements.instance.saveAttributes.levelsUnlocked ? currentIndex + 1 : Achievements.instance.saveAttributes.levelsUnlocked;
            //Show ads on android
#if UNITY_ANDROID
            if(GameManager.instance.ads)
            {
                if (adLastShown >= 2)
                {
                    if (Advertisement.IsReady())
                    {
                        Advertisement.Show();
                        adLastShown = 0;
                    }
                }
                else
                {
                    adLastShown++;
                }
            }
#endif
            LoadLevel(levelProgression.levels[currentIndex + 1]);
        }
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
