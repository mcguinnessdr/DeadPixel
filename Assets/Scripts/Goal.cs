using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    public float rotateSpeed;
    public string nextLevel;

	void Update () {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        var player = col.gameObject.GetComponent<Player>();
        if (player)
        {
            LevelManager.instance.LoadNextLevel();
        }
    }
}
