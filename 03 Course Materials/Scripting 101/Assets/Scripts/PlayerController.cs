using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;

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
	}

    void Move(float horizontal, float vertical)
    {
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        //transform.Translate(speed * dir * Time.deltaTime); non physics method

        rigidbody.AddForce(dir * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        _GM.Score--;
    }
}
