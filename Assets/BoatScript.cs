using System;
using System.Linq;
using UnityEngine;
using System.Collections;

public class BoatScript : MonoBehaviour {

    public float MaxRotationZ = -0.15f;
    public float RotationSpeedZ = 5f;

    public float MaxMoveY = 0.001f;
    public float MoveSpeedY = 5f;

    public float MoveSpeedX = -0.002f;

    private bool _sinking = false;
    private float _sinkTime = 0.0f;
    private float _deactivationTimeout = 4f;

    private Animator _animator;
    private GameObject _worldObject;

    public int SinkPoints = 10;
    public int BumpHeadPunish = 5;

    public Animator GetAnimator
    {
        get
        {
            if (_animator != null) _animator = this.GetComponent<Animator>();
            return _animator;
        }
    }

    // Use this for initialization
	void Start ()
	{
	    _worldObject = GameObject.FindWithTag("GameController");
        if (_worldObject == null) Debug.Log("cannot find world object");
	}

    void FixedUpdate()
    {
        if (_sinking)
            SinkBoat();
        else
            MoveBoat();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        BumpHead(other.gameObject);
        if (other.gameObject.tag == "Player")
        {
            _worldObject.GetComponent<GuiScript>().SubtractScore(BumpHeadPunish);
        }
    
    }
    
    void OnCollisionStay2D(Collision2D other)
    {
        BumpHead(other.gameObject);
    }
    
    void BumpHead(GameObject otherObject)
    {
        if (otherObject.tag == "Player")
        {
            otherObject.rigidbody2D.AddForce(new Vector2(0, -2));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _sinkTime = Time.realtimeSinceStartup;
            _worldObject.GetComponent<GuiScript>().AddScore(SinkPoints);
            foreach (var col in gameObject.GetComponents<Collider2D>())
            {
                col.enabled = false;    
            }
            _sinking = true;
            //GetAnimator.SetBool("Sinking", true);
        }
    }

    void SinkBoat()
    {
        var depth = -0.002f *(Time.realtimeSinceStartup - _sinkTime);
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + depth, 1);
        
        var rotation = Math.Max(-0.1f * (Time.realtimeSinceStartup - _sinkTime), -1);
        gameObject.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, rotation, transform.rotation.w);

        if (Time.realtimeSinceStartup > _sinkTime + _deactivationTimeout)
        {
            Deactivate();
        }
    }

    void MoveBoat()
    {
        var moveY = MaxMoveY * Mathf.Sin(MoveSpeedY * Time.realtimeSinceStartup);
        var rotationZ = MaxRotationZ * Mathf.Sin(RotationSpeedZ * Time.realtimeSinceStartup);

        gameObject.transform.position = new Vector3(
            transform.position.x + MoveSpeedX,
            transform.position.y + moveY,
            transform.position.z);

        gameObject.transform.Rotate(0, 0, rotationZ);
        foreach (var col in gameObject.GetComponents<Collider2D>())
        {
            col.enabled = true;
        }
    }

    public void Activate(float offset)
    {
        Debug.Log("set active with x offset " + offset);
        _sinking = false;
        _sinkTime = 0;
        transform.position = new Vector3(1.5f + offset, 0.3f, -2);
        transform.rotation = new Quaternion(0,0,0,0);
        //GetAnimator.SetBool("Sinking", false);
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        Debug.Log("Deactivate Boat");
        this.gameObject.SetActive(false);
    }
}
