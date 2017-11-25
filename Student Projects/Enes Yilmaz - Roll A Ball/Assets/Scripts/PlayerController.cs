using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//
//Merhaba Enes :)
//Ödev için çok teşekkür ederim
//Bu yorumlar bir sonraki commit'imle birlikte refactor edilmiş (düzenlenmiş) kod düzenine geçecek.
//Şuan için bu commit'imde eksiklerini veya yorumlarımı not aldım.
//

public class PlayerController : MonoBehaviour {

    public Rigidbody rigidbody;
    public float speed = 10f;

    //UI tanımlamarında tipi ben en başa yazmayı tercih ediyorum.
    public Text scoreText; //txtScore
    public Text winText;   //txtWin

    //Burada bu değişken bir text'e data olarak bind edilmesi gerekiyor ki daha kolay kullanılsın. 
    //Bind (Bağlamak)
    //Yani data değiştiğinde -score artıp azaldığında- ilgili text UI otomatik olarak kendini güncellesin.
    //Bunu yapmanın yoluysa encapculation'dan geçiyor.
    private int score;
	void Start () {
        rigidbody = GetComponent<Rigidbody>();

        //Encapculation yapıldığında bu 3 satır kendiliğinden silinip 1 satırla, kod temizlenmiş olacak.
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

    //Bu fonksiyon gayet başarılı olmuş. 
    //Şuanki öğrettiklerimle elinizden gelenin en iyisi budur.
    //Çoğu kişi zıplamayı yaptığında havada tekrar zıplamayı iptal edemiyordur.
    //Raycast denilen sistemi önümüzdeki ders göstereceğim zaten. 
    //Bu işin üstesinden nasıl gelindiğini göreceksiniz.
    //Eline sağlık :)
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

            //Bak mesela, hem score++ hem SetScoreText kısmı çok çirkin değil mi sencede?
            //İkisi de bir bakıma similar (benzer) görevleri üstleniyorlar.
            //İkisi de score ile ilgileniyorlar.
            //Enkapsülleyince burası da düzelecek.
            score++;
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);

            //Oyun esnasında gerekmedikce Find fonksiyonlarıyla Unity'i meşgul etmek performans sorunlarına yol açar.
            //Şuan için çok küçük bir proje olduğundan sorun olmayacaktır ancak,
            //Bu Find ile referans alma işlemlerini Start ya da Awake fonksiyonunda gerçekleştirip,
            //Bir değişkende saklamak lazım.
            //RAM'i şişirip, CPU'yu olabildiğince rahatlatmak lazım.
            Destroy(GameObject.FindWithTag("Door"));
        }
    }

    //Burası kapsüllemenin set bölümünün içerisine gidecek.
    void SetScoreText()
    {
        scoreText.text = "Score:" + score;
        if (score >= 6)
        {
            winText.text = "You Win";
        }
    }
}
