using System;
using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiverScript : MonoBehaviour {

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private const float OxyLostPerUpdate = 0.001f;
    private float _oxygenLevel;

    private GuiScript _guiScript;

    private bool _drowned;

    public GameObject MedOxyFacialOverlay;
    public GameObject LowOxyFacialOverlay;
    public GameObject CriticalOxyFacialOverlay;

    public AudioClip SwimUpSound;
    public AudioClip BreatheSound;

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
        if (_oxygenLevel <= 0.5f) MedOxyFacialOverlay.SetActive(true);
        if (_oxygenLevel <= 0.2f) LowOxyFacialOverlay.SetActive(true);
        if (_oxygenLevel <= 0.1f) CriticalOxyFacialOverlay.SetActive(true);
        if (_oxygenLevel < 0) StartCoroutine(Drown());
    }

    private IEnumerator Drown()
    {
        Debug.Log("You drowned");
        _drowned = true;
        ResetFacialOverlays();
        _animator.SetBool("Drowned", true);
        yield return new WaitForSeconds(2);
        _rigidbody2D.gravityScale *= -1;
    }

    private void ListenToInput()
    {
        var click = Input.GetMouseButtonDown(0);
        _animator.SetBool("SwimUp", click);
        if (click)
        {
            _rigidbody2D.AddForce(new Vector2(0, 2));
            audio.PlayOneShot(SwimUpSound);
        }
    }

    public void Breathe()
    {
        if (_drowned) return;
        _oxygenLevel = 1f;
        _guiScript.UpdateOxygenLevel(_oxygenLevel);
        ResetFacialOverlays();
        audio.PlayOneShot(BreatheSound);
    }

    private void ResetFacialOverlays()
    {
        MedOxyFacialOverlay.SetActive(false);
        LowOxyFacialOverlay.SetActive(false);
        CriticalOxyFacialOverlay.SetActive(false);
    }

    public bool IsAlive()
    {
        return !_drowned;
    }

}
