using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIt : MonoBehaviour {

    public float speed = 25f;
    public float randomMax = 50f;
    public float randomMin = 25f;

    void Start()
    {
        SetRandomness();   
    }

    void Update()
    {
        Rotate();    
    }

    /// <summary>
    /// Set random speed values.
    /// </summary>
    void SetRandomness()
    {
        speed = Random.Range(randomMin, randomMax);
    }

    /// <summary>
    /// Rotate the object along Z axis by time.
    /// </summary>
    void Rotate()
    {
        Vector3 direction = Vector3.forward;
        transform.Rotate(direction * speed * Time.deltaTime);
    }
}
