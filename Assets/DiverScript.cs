using UnityEngine;
using System.Collections;

public class DiverScript : MonoBehaviour {

    private Animator _animator;
    private Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    var click = Input.GetMouseButtonDown(0);
	    _animator.SetBool("SwimUp", click);
	    if (click) rigidbody2D.AddForce(new Vector2(0,2));
	}
}
