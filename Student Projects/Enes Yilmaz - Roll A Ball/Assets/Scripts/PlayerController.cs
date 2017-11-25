using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Rigidbody rigidbody;
    public float speed = 10f;
    public Text scoreText;
    public Text winText;

    private int score;
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winText.text = "";
	}


	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Move(horizontal, vertical);
    }

    void Move(float horizontal, float vertical)
    {
        Vector3 dir = new Vector3(horizontal, 0, vertical);

        rigidbody.AddForce(dir * speed);
    }
    void Jump()
    {
        if (transform.localPosition.y == 0.5 || transform.localPosition.y == 1.5 || transform.localPosition.y == 4 || transform.localPosition.y == 5)
        {
            Vector3 dir = new Vector3(0, 400f, 0);
            rigidbody.AddForce(dir);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            Destroy(GameObject.FindWithTag("Door"));
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score:" + score;
        if (score >= 6)
        {
            winText.text = "You Win";
        }
    }
}
