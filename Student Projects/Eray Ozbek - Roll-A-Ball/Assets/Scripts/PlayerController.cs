using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Api;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 500.0f;
    public int Count
    {
        get { return count; }
        set
        {
            count = value;
            txtScore.text = "Score: " + count;

            if (count >= 30)
                ShowObject(txtWin.gameObject);
        }
    }

    private int count;
    private Text txtScore; 
    private Text txtWin;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        txtScore = GameObject.Find("ScoreText").GetComponent<Text>();
        txtWin = GameObject.Find("WinText").GetComponent<Text>();

        HideObject(txtWin.gameObject);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Movement(moveHorizontal, moveVertical);
    }

    void Movement(float horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rigidbody.AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            HideObject(other.gameObject);

            Count++;
        }
    }

    void HideObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    void ShowObject(GameObject obj)
    {
        obj.SetActive(true);
    }
}
