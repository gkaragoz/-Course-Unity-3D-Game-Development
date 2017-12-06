using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform healthGameObject;

    private float _health;

    public float Health
    {
        get { return _health; }
        set {
            _health = value;
            SetHealthGraphics();
        }
    }

    public Transform bulletSlot;
    public GameObject bulletPrefab;

    void Start()
    {
        Health = 100;
    }

    void SetHealthGraphics()
    {
        healthGameObject.localScale = (new Vector3(_health / 100f, 1, 1));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion direction = TankController.instance.LookToMouse2D();
            GameObject bullet = Instantiate(bulletPrefab, bulletSlot.position, direction);

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - objectPos;

            bullet.GetComponent<BulletManager>().direction = dir;
        }

        Health -= 5 * Time.deltaTime;
    }
	
}
