using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject [] golds;

	void Start () {
        golds = GameObject.FindGameObjectsWithTag("Gold");
	}
	
	void Update () {
		
	}
}
