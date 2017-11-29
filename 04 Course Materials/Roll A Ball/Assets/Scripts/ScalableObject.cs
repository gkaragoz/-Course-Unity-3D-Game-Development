using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalableObject : MonoBehaviour {

    public Vector3 newScale;

    private void Start()
    {
        newScale = transform.localScale;
    }

    /// <summary>
    /// Change scale of gameObject. The parameter makes bigger or smaller. Default is make it bigger.
    /// </summary>
    /// <param name="oppositeScale"></param>
    public void ScaleIt(int oppositeScale = 1)
    {
        Vector3 currentScale = transform.localScale;

        transform.localScale = new Vector3(
            currentScale.x + newScale.x * 0.5f * oppositeScale, 
            currentScale.y + newScale.y * 0.5f * oppositeScale, 
            currentScale.z + newScale.z * 0.5f * oppositeScale);

        if (transform.localScale.magnitude <= 1)
            transform.localScale = currentScale;
    }

}
