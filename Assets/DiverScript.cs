using System;
using UnityEngine;
using System.Collections;

public class DiverScript : MonoBehaviour {

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private const float OxyLostPerUpdate = 0.001f;
    private float _oxygenLevel;

    private GuiScript _guiScript;

    private bool _drowned;

    // Use this for initialization
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _rigidbody2D = this.GetComponent<Rigidbody2D>();

        _guiScript = GameObject.FindWithTag("GameController").GetComponent<GuiScript>();
        _drowned = false;
        Breathe();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        if (_drowned) return;
        ListenToInput();
        ManageOxygen();
	}

    private void ManageOxygen()
    {
        _oxygenLevel -= OxyLostPerUpdate;
        _guiScript.UpdateOxygenLevel(_oxygenLevel);
        if (_oxygenLevel < 0) StartCoroutine(Drown());
    }

    private IEnumerator Drown()
    {
        Debug.Log("You drowned");
        _drowned = true;
        _animator.SetBool("Drowned", true);
        yield return new WaitForSeconds(2);
        _rigidbody2D.gravityScale *= -1;
    }

    private void ListenToInput()
    {
        var click = Input.GetMouseButtonDown(0);
        _animator.SetBool("SwimUp", click);
        if (click) _rigidbody2D.AddForce(new Vector2(0, 2));
    }

    public void Breathe()
    {
        if (_drowned) return;
        _oxygenLevel = 1f;
        _guiScript.UpdateOxygenLevel(_oxygenLevel);
    }

    public bool IsAlive()
    {
        return !_drowned;
    }

}
