using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    public ScalableObject scalableObj;

    private RaycastHit _hit;

    void Update()
    {
        CheckClick();
    }

    /// <summary>
    /// Checks Right or left click events.
    /// </summary>
    void CheckClick()
    {
        //Mouse left click.
        if (Input.GetMouseButtonDown(0))
            Interact();
        //Right mouse click.
        else if (Input.GetMouseButtonDown(1))
            Interact(-1);
    }

    /// <summary>
    /// Interact with objects via Raycast. The objects must have at least 1 collider.
    /// </summary>
    /// <param name="oppositeScale"></param>
    void Interact(int oppositeScale = 1)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hit))
        {
            scalableObj = _hit.collider.gameObject.GetComponent<ScalableObject>();
            if (scalableObj != null)
                scalableObj.ScaleIt(oppositeScale);
        }
    }
}
