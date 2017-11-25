using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//Merhaba Kerem :)
//Ödev için çok teşekkür ederim
//Bu yorumlar bir sonraki commit'imle birlikte refactor edilmiş (düzenlenmiş) kod düzenine geçecek.
//Şuan için bu commit'imde eksiklerini veya yorumlarımı not aldım.
//

public class TopKontrol : MonoBehaviour
{

    //Her şeyden önce TÜRKÇE kod düzeninden uzak durmalısın.
    //Muhakkak! İngilizce değişken tanımlamalısın.
    //İngilizce'sini bilmiyorsan hemen Goolge Translate'ten kelime çevirisi yapman lazım.
    //Böyle böyle, tüm oyun terimlerine de aşina olur, şayet İngilizce'n zayıfsa, gelişimine katkıda bulunmuş olursun.

    //Yazdığın kodları daha düzenli hale getirirsen çok iyi olur.
    //Örneğin Control fonksiyonundaki if yapısının içi oldukça düzensiz.
    //Tab'a fazla basmak, gereksiz boşluk bırakmaktan bahsediyorum.


    public Rigidbody rb;
    public float hiz = 3f; //speed.


    // Use this for initialization
    void Start()
    {
        //UI sistemini göstermiş olmam gerekiyor derste.
        //Şayet erken çıktıysan kaçırmış olabilirsin.
        //Dolayısıyla bunu UI ile yapmanı yeğlerdim :)
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
                    
                    //Ziplama kontrollerini böyle yapman oldukça doğal.
                    //Şuan için Raycast konularını işlemediğimiz için,
                    //Yapabileceğinin en iyisi şeklinde bir çözüm uygulamışsın.
                    //Oldukça da güzel olmuş, tebrik ederim :)
                    Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
                    if (rb.transform.position.y < 1.2)
                    {
        
                        GetComponent<Rigidbody>().AddForce(jump);
                    }
        
                }
                float DuseyHareket = Input.GetAxis("Horizontal");
                float Dikeyhareket = Input.GetAxis("Vertical");

                //Kontrol fonksiyonunun içerisinde neden hareketi gerçekleştiren eylemler var?
                //OOP mantığına göre bu kodların ayrı bir fonksiyonda olması gerek.
                Vector3 hareket = new Vector3(DuseyHareket * hiz, 0, Dikeyhareket * hiz);
                rb.AddForce(hareket);
    }
}
