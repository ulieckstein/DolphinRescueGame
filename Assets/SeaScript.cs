using UnityEngine;
using System.Collections;

public class SeaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public float Speed = -0.002f;

	void FixedUpdate () {
        gameObject.transform.position = new Vector3(
        transform.position.x + Speed,
        transform.position.y,
        transform.position.z);

	    if (transform.position.x < -1.28f)
	    {
	        Debug.Log("became invisible");
	        gameObject.transform.position = new Vector3(2.55f, transform.position.y, transform.position.z);
	    }
	}
}
