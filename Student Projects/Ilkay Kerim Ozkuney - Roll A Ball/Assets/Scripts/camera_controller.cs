﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour{

    public GameObject Player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}