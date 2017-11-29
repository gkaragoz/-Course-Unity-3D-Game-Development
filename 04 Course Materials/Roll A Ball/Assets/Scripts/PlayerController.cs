using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public Text txtScore;

    private int _score;
    private RaycastHit _hit;

    /// <summary>
    /// Encapculation for _score variable.
    /// </summary>
    public int Score
    {
        get { return _score; }
        set {
            _score = value;
            txtScore.text = "Score: " + _score.ToString();
        }
    }
    private Rigidbody _rigidbody;
    
    /// <summary>
    /// Get references and make initalizations.
    /// </summary>
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        txtScore = GameObject.Find("txtScore").GetComponent<Text>();
        Score = 0;
    }

    /// <summary>
    /// Raycast and Input controllers
    /// </summary>
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

    /// <summary>
    /// Jump function with hardcode 500f force.
    /// </summary>
    void Jump()
    {
        _rigidbody.AddForce(Vector3.up * 500f);
    }

    /// <summary>
    /// Move function with AddForce. We multiplied by -1 because Camera direction.
    /// </summary>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    void Movement(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        _rigidbody.AddForce(direction * -1 * speed);
    }

    /// <summary>
    /// Check for Death and Gold triggers.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DEATH_TRIGGER")
            Death();

        Score++;
        Destroy(other.gameObject);
    }

    /// <summary>
    /// If we need to die, here is the function.
    /// </summary>
    void Death()
    {
        Application.LoadLevel("Main");
    }
}
