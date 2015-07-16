using System;
using UnityEngine;
using System.Collections;

public class DiverScript : MonoBehaviour {

    private Animator _animator;
    private Rigidbody2D rigidbody2D;
    
    private float _oxyLostPerUpdate = 0.001f;
    private float _oxygenLevel;

    private GuiScript _guiScript;

    // Use this for initialization
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();

        _guiScript = GameObject.FindWithTag("GameController").GetComponent<GuiScript>();
        Breathe();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    var click = Input.GetMouseButtonDown(0);
	    _animator.SetBool("SwimUp", click);
	    if (click) rigidbody2D.AddForce(new Vector2(0,2));

	    _oxygenLevel -= _oxyLostPerUpdate;
        _guiScript.UpdateOxygenLevel(_oxygenLevel);
	}

    public void Breathe()
    {
        _oxygenLevel = 1f;
        _guiScript.UpdateOxygenLevel(_oxygenLevel);
    }


}
