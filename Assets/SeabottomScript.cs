using UnityEngine;
using System.Collections;

public class SeabottomScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerDrowned(other.gameObject);
    }

    void PlayerDrowned(GameObject otherObject)
    {
        //aktuell noch kein game-over event --> spieler wird einfach wieder hochgeschubst
        if (otherObject.tag == "Player")
        {
            otherObject.rigidbody2D.AddForce(new Vector2(0, 6));
        }
    }
}
