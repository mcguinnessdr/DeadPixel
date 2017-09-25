using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    public float delay;

	void Start () {
        Invoke("DestroyInvoke", delay);
	}
	
    void DestroyInvoke()
    {
        Destroy(gameObject);
    }

}
