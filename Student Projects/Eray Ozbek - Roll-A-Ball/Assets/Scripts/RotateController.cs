using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour {

    public float rotateSpeedX = 15f;
    public float rotateSpeedY = 30f;
    public float rotateSpeedZ = 45f;

	void Update ()
    {
        Rotate(this.gameObject);
	}

    void Rotate(GameObject obj)
    {
        Vector3 direction = new Vector3(rotateSpeedX, rotateSpeedY, rotateSpeedZ);
        obj.transform.Rotate(direction * Time.fixedDeltaTime);
    }
}
