using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public Text txtScore;

    private int _score;
    private RaycastHit _hit;

    public int Score
    {
        get { return _score; }
        set {
            _score = value;
            txtScore.text = "Score: " + _score.ToString();
        }
    }
    private Rigidbody _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        txtScore = GameObject.Find("txtScore").GetComponent<Text>();
        Score = 0;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Movement(horizontal, vertical);

        //Vector3 forward = Vector3.down * 10;
        //Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, Vector3.down, out _hit))
        {
            float distance = Vector3.Distance(transform.position, _hit.point);
            if (distance <= 0.56f)
            {
                if(Input.GetKeyDown("space"))
                    Jump();
            }
        }
    }

    void Jump()
    {
        _rigidbody.AddForce(Vector3.up * 500f);
    }

    void Movement(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        _rigidbody.AddForce(direction * -1 * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);

        if (other.gameObject.name == "DEATH_TRIGGER")
            Death();

        Score++;
        Destroy(other.gameObject);
    }

    void Death()
    {
        Application.LoadLevel("Main");
    }
}
