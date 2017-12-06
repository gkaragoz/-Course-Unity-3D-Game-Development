using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Collectable")
            transform.position = CollectableGenerator.instance.GetRandomPosition();
    }
}
