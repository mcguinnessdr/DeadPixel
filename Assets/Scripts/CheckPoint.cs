using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    bool active;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (active) return;
        var player = col.gameObject.GetComponent<Player>();
        if (player)
        {
            player.spawnPoint = transform.position;
            active = true;
            GetComponent<Animator>().SetBool("Set", true);
        }
    }
}
