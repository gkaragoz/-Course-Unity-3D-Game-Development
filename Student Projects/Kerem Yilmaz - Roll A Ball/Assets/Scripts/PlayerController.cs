using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float gravity = 20.0f;
    public int forceConst =115;

    private bool canJump;
    private GameManager _GM;
    private Rigidbody rigidbody;

	void Start () {
        _GM = GameObject.FindObjectOfType<GameManager>();
        //_GM = GameObject.Find("_GAMEMANAGER").GetComponent<GameManager>();

        rigidbody = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Move(horizontal, vertical);
        if (canJump)
        {
            canJump = false;
            rigidbody.AddForce(0, forceConst/15, 0, ForceMode.Impulse);
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canJump = true; // tuşa basıldıgında komutu calistirir
        }
    }
    void Move(float horizontal, float vertical)
    {
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        //transform.Translate(speed * dir * Time.deltaTime); non physics method

        rigidbody.AddForce(dir * speed);
    }

    void OnTriggerEnter(Collider other)
    { 
        Destroy(other.gameObject); //destroyfonksiyonu etkileşi hlainde yok eder
        _GM.Score--;
    }
}
