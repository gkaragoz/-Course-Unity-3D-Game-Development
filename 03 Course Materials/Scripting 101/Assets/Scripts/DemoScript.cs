using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour {

    void BenimFonksiyonum()
    {
        Debug.Log("Benim Fonksiyonum çalıştı.");
    }

    void BenimIkinciFonksiyonum()
    {
        Debug.Log("İkinci fonksiyon çalıştı.");
    }

    void Awake()
    {
        BenimFonksiyonum();
    }

    void Start () {
        BenimIkinciFonksiyonum();
	}
	
	void Update () {
		
	}
}
