using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffLight : MonoBehaviour {

    public Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
            OnOff();
    }

    void OnOff()
    {
        light.enabled = !light.enabled;
    }
}
