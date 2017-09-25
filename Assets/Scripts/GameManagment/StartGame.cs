using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public string level;

    public void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelManager.instance.levelProgression.levels[0]);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quit()
    {
        print("quitting");
        Application.Quit();
    }
}
