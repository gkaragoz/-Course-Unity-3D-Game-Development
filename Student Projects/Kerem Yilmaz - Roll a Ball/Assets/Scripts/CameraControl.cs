using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

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
