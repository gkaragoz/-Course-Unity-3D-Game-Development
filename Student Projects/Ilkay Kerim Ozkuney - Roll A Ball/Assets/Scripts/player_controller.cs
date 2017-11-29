using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    private int collectiblecount;
    public Text WinText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        collectiblecount = 0;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collectible")) 
        {
            
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            collectiblecount = collectiblecount + 1;
        }
        if (other.gameObject.CompareTag("penalty"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
        }
        
        if(collectiblecount >= 10)
        {
            WinText.gameObject.SetActive(true);
        }
        
    }
    void SetCountText()
    {
    countText.text="Score:"+count.ToString();
    }
}

