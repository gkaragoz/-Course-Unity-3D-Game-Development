using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public Rigidbody rigidbody;

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical);
        // transform.Translate(speed * dir * Time.deltaTime); non physics method
    
        rigidbody.AddForce(dir * speed);
	}
}
