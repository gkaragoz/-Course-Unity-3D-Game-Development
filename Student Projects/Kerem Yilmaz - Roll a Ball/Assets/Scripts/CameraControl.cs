using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//Merhaba Kerem :)
//Ödev için çok teşekkür ederim
//Bu yorumlar bir sonraki commit'imle birlikte refactor edilmiş (düzenlenmiş) kod düzenine geçecek.
//Şuan için bu commit'imde eksiklerini veya yorumlarımı not aldım.
//

public class CameraControl : MonoBehaviour
{
    //Tüm bunları parent-child ilişkisiyle yapabileceğimizi göstermiştim.
    //Dolayısıyla CPU'yu gereksizce işleme tabii tutup yormak yerine,
    //Unity'nin verdiği imkanları kullanmak daha doğru olur.

    public GameObject oyuncu;
    private Vector3 Offset;
    // Use this for initialization
    void Start()
    {
        Offset = transform.position - oyuncu.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = oyuncu.transform.position + Offset;

    }
}
