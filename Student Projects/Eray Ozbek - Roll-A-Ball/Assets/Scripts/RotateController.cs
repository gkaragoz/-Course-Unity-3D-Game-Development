using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//Merhaba Eray :)
//Ödev için çok teşekkür ederim
//Bu yorumlar bir sonraki commit'imle birlikte refactor edilmiş (düzenlenmiş) kod düzenine geçecek.
//Şuan için bu commit'imde eksiklerini veya yorumlarımı not aldım.
//

public class RotateController : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        //Bu komut için aslında bir fonksiyon yazman OOP açısından daha doğru olurdu.
		transform.Rotate(new Vector3(15,30,45) * Time.fixedDeltaTime);
	}
}
