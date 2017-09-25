using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public bool paused;
    public UnityEvent OnPause;
    public UnityEvent OnUnpause;
	
	void Update () {
        if (LevelSettings.instance == null || !LevelSettings.instance.Pausable)
            return;
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if(!paused)
            {
                pause();
            }else
            {
                Unpause();
            }
        }
	}

    public void pause()
    {
        if (paused)
            return;
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
        Time.timeScale = 0;
        paused = true;
        OnPause.Invoke();
    }

    public void Unpause()
    {
        if (!paused)
            return;
        Time.timeScale = 1;
        paused = false;
        OnUnpause.Invoke();
        SceneManager.UnloadSceneAsync("PauseMenu");
    }
}
