using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public Vector2 speed;

	void Start () {
        GetComponent<Rigidbody2D>().velocity = speed;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        var player = col.gameObject.GetComponent<Player>();
        if (player)
        {
            player.kill();
        }
        Destroy(gameObject);
    }
}
