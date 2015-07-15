using System;
using UnityEngine;
using System.Collections;

public class WaveScript : MonoBehaviour
{

    public float MaxMoveX = 0.005f;
    public float MoveSpeedX = 5f;

    public float MaxMoveY = 0.001f;
    public float MoveSpeedY = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate ()
	{
	    var moveY = MaxMoveY*Mathf.Sin(MoveSpeedY*Time.realtimeSinceStartup);
        var moveX = MaxMoveX * Mathf.Sin(MoveSpeedX * Time.realtimeSinceStartup);

	    gameObject.transform.position = new Vector3(
            transform.position.x + moveX, 
            transform.position.y + moveY,
	        transform.position.z);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        PushDownPlayer(other.gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        PushDownPlayer(other.gameObject);
    }

    void PushDownPlayer(GameObject otherObject)
    {
        if (otherObject.tag == "Player")
        {
            otherObject.rigidbody2D.AddForce(new Vector2(0, -4));
            otherObject.GetComponent<DiverScript>().Breathe();
        }
    }
}
