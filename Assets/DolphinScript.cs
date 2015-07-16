using UnityEngine;
using System.Collections;

public class DolphinScript : MonoBehaviour
{
    public float CaughtMoveSpeed = -0.002f;
    public float SwimmingMoveSpeed = -0.004f;
    
    private float MoveX;
    
    private Animator _animator;
    private GuiScript _guiScript;

    private int RescuePoints = 20;
    
    // Use this for initialization
	void Start () {
        _guiScript = GameObject.FindWithTag("GameController").GetComponent<GuiScript>();
        _animator = this.GetComponent<Animator>();
	    MoveX = CaughtMoveSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.position = new Vector3(
                transform.position.x + MoveX,
                transform.position.y,
                transform.position.z);
	}
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Animator>().SetTrigger("Cut");
            StartCoroutine(FreeDolphin());
        }
    }

    private IEnumerator FreeDolphin()
    {
        yield return new WaitForSeconds(0.3f); 
        _animator.SetBool("IsFreed", true);
        gameObject.transform.position = new Vector3(
            transform.position.x,
            transform.position.y - 0.18f,
            transform.position.z);
        MoveX = SwimmingMoveSpeed;
        _guiScript.AddScore(RescuePoints);
    }

    public void Activate(float offset)
    {
        //_animator.SetBool("IsFreed", false);
        transform.position = new Vector3(offset, 0.007f, 0);
        MoveX = CaughtMoveSpeed;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
