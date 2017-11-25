using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Rigidbody rigidbody;
    public float speed = 10f;

    private GameObject doorObj;
    private Text txtScore;
    private Text txtWin;
    private int requiredGoldCount; //Hard string olarak 23. satırdaki if kontrolü için ekrandaki toplanılması gereken total puanları tutan bir değişken. Statik değil, dinamik olacağız.
    private int score;

    public int Score
    {
        get { return score; }
        set {
            score = value;
            txtScore.text = "Score:" + score;
            if (score >= requiredGoldCount)
                txtWin.text = "You Win";
        }
    }


    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        doorObj = GameObject.Find("Door");
        txtScore = GameObject.Find("txtScore").GetComponent<Text>();
        txtWin = GameObject.Find("txtWin").GetComponent<Text>();

        requiredGoldCount = GameObject.Find("Golds").transform.childCount;
        Score = 0;
	}

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

    //Raycast sistemini öğrendiğimizde refactor edeceğiz.
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
            Score++;
        }

        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            Destroy(doorObj);
        }
    }
}
