using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIt : MonoBehaviour {

    public float rotationSpeed = 25f;

    private float[] _clokwise = new float[] { -1 , 1 };

    void Start ()
    {
        int randomValue = Random.Range(0, 2);
        rotationSpeed *= _clokwise[randomValue];
    }

	void Update () {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
	}
}
