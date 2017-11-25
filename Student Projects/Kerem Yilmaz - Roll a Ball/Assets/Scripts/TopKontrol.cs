using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopKontrol : MonoBehaviour
{

    public Rigidbody rb;
    public float hiz = 3f;


    // Use this for initialization
    void Start()
    {
        Debug.Log("4 katli bloglari gecmek icin cift ziplama kullanabilirsin");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }
    private void Control()
    {
        if (Input.GetKeyDown("space"))
                {
        
                    Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
                    if (rb.transform.position.y < 1.2)
                    {
        
                        GetComponent<Rigidbody>().AddForce(jump);
                    }
        
                }
                float DuseyHareket = Input.GetAxis("Horizontal");
                float Dikeyhareket = Input.GetAxis("Vertical");
                Vector3 hareket = new Vector3(DuseyHareket * hiz, 0, Dikeyhareket * hiz);
                rb.AddForce(hareket);
    }
}
