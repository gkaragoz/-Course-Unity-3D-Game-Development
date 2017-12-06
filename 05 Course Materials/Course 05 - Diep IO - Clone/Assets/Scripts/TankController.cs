using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    public static TankController instance;

    public float speed = 5f;

    public Rigidbody2D rb2D;
    public Transform body;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        LookToMouse2D();
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(horizontal, vertical);

        rb2D.AddForce(dir * speed);
    }

    public Quaternion LookToMouse2D()
    {
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - objectPos;
        Quaternion lastRotationStatus = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));

        body.transform.rotation = lastRotationStatus;
        return lastRotationStatus;
    }
}
