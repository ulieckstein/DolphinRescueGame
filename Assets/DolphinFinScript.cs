using UnityEngine;
using System.Collections;

public class DolphinFinScript : MonoBehaviour
{
    public float MoveSpeed;

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(
        transform.position.x < -1 ? 1.3f : transform.position.x + MoveSpeed,
        transform.position.y,
        transform.position.z);
    }
    
}
