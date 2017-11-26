using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Api;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 500.0f;
    public Text scoreText;
    private int count = 0;
    public Text WinText;
    

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;     
            scoreText.text = "Score: " + count;
        }

        if (count >= 30) 
        {
            WinText.gameObject.SetActive(true);
        }
    }

    

}
