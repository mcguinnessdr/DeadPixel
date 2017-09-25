using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireProjectile : MonoBehaviour {

    public Transform projectile;
    public float delay;
    public Vector2 speed;

	void Start () {
        InvokeRepeating("fire", 0f, delay);
	}

    void fire()
    {
        Instantiate(projectile, transform.position, transform.rotation).GetComponent<projectile>().speed = speed;
    }
}
