﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    public Vector3 offset;

    void Start()
    {
        if (GameObject.Find("Player") != null)
            target = GameObject.Find("Player");
    }

	void Update () {
        SetCameraPosition();
	}

    /// <summary>
    /// Setting the camera position depends on target position. 
    /// Make sure you have offset value!
    /// </summary>
    void SetCameraPosition()
    {
        transform.position = new Vector3(
            target.transform.position.x + offset.x,
            target.transform.position.y + offset.y, 
            target.transform.position.z + offset.z);
    }
}
