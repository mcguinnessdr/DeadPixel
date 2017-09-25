using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public Transform player;
    public float speed;

	void Start () {
        player = FindObjectOfType<Player>().GetComponent<Transform>();
	}
	
	void LateUpdate () {
        //transform.position += ((player.position - transform.position) * speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, -10), speed * Time.deltaTime);
	}
}
