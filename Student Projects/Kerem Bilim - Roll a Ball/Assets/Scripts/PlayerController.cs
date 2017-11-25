using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float jumpPower = 1f;

    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector3 jumpDirection = new Vector3(0.0f, 200.0f, 0.0f);
            if (rigidbody.transform.position.y < 1.2)
                rigidbody.AddForce(jumpDirection * jumpPower);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Move(horizontal, vertical);
    }

    private void Move(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        rigidbody.AddForce(direction * speed);
    }
}
