using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

    void Start()
    {
        Debug.Log("DestroyerScript activated");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boat")
        {
            var boatScript = other.gameObject.GetComponent<BoatScript>();
            if (boatScript != null) boatScript.Deactivate();
        }
        if (other.gameObject.tag == "Dolphin")
        {
            var dolphinScript = other.gameObject.GetComponent<DolphinScript>();
            if (dolphinScript != null) dolphinScript.Deactivate();
        }
    }
}
