using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//Merhaba Eray :)
//Ödev için çok teşekkür ederim
//Bu yorumlar bir sonraki commit'imle birlikte refactor edilmiş (düzenlenmiş) kod düzenine geçecek.
//Şuan için bu commit'imde eksiklerini veya yorumlarımı not aldım.
//

public class CameraController : MonoBehaviour
{

    public GameObject player; //player objectin public olmasına karşın 
                              //yine de start fonksiyonun içinde referans alman daha güzel olurdu. 
                              //Çünkü, şayet bir bölüm seçim ekranın olsaydı, 
    //ilgili bölüm seçildiğinde muhtemelen sahne yüklendiğinde,
    //player objectini buradaki değişkene sürükle bırak yapman kabul edersin ki mümkün olmayacak.
    //dolayısıyla daima Start ya da Awake fonksiyonunda Find komutlarından istersen tag ile,
    //istersen isim ile, istersen de objectTipi ile nesnenin referansını almalısın.

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

}
