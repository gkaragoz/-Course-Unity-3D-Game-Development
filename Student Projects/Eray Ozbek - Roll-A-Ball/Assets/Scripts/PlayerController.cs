using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Api;
using UnityEngine;
using UnityEngine.UI;

//
//Merhaba Eray :)
//Ödev için çok teşekkür ederim
//Bu yorumlar bir sonraki commit'imle birlikte refactor edilmiş (düzenlenmiş) kod düzenine geçecek.
//Şuan için bu commit'imde eksiklerini veya yorumlarımı not aldım.
//

public class PlayerController : MonoBehaviour
{
    //UI değişkenlerinin public olmasının bu kapsamda bir mantığı yok.
    //Sürükle bırak referans atamalarından daima kaçınmalıyız.
    //Start ya da Awake fonksiyonun içerisinde ilgili nesneleri Find
    //methodlarından uygun bir tanesini kullanarak nesne referanslamarımızı
    //yapmamız daha doğru olur.

    public float speed = 500.0f;
    public Text scoreText;  //Bu tip değişkenlerin isimlerini scoreText yerine 
    //txtScore gibi önce tip, sonra isim şeklinde yapman literatüre daha uygun olabilir.
    private int count = 0;
    public Text WinText;
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //OOP açısından aşağıdaki 2 satır FixedUpdate'in görevi olan bir komut seti değil.
        //Move gibi bir fonksiyonla ayrıca çağırman daha doğru olurdu.
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            //Hide object gibi bir fonksiyon neden olmasın?
            other.gameObject.SetActive(false);

            //Fark ettin mi bilmiyorum ama,
            //Aşağıdaki iki satır da neredeyse benzer görevleri yapıyor.
            //Yani aynı amaç için çalışıyorlar
            //Ekranda skoru gösterebilmek!
            //Dolayısıyla bu iki satırı tek satıra indirmenin bir yolu var.
            //Encapculation!
            //Datayı yani count değişkenini text UI'ına "Bind" (bağlama) edebiliriz.

            count += 1;     
            scoreText.text = "Score: " + count;
        }

        //Show text diye bir fonksiyon neden olmasın?
        if (count >= 30) 
        {
            WinText.gameObject.SetActive(true);
        }
    }

    

}
