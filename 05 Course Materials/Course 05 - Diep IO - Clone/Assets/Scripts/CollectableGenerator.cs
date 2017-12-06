using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGenerator : MonoBehaviour {

    public static CollectableGenerator instance; 

    public Transform collectablesParentObject;
    public GameObject[] instPrefabs;
    public Transform[] mapPositions;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start () {
        for (int ii = 0; ii < 100; ii++)
            Generate();

        //Generating
        InvokeRepeating("Generate", 0f, 1f);
	}
	
    public Vector2 GetRandomPosition()
    {
        float x = Random.Range(mapPositions[0].position.x, mapPositions[1].position.x); //BottomLeft and BottomRight
        float y = Random.Range(mapPositions[2].position.y, mapPositions[0].position.y); //TopLeft and BottomLeft

        Vector2 position = new Vector2(x, y);

        return position;
    }

    void Generate()
    {
        GameObject go = instPrefabs[Random.Range(0, instPrefabs.Length)];
        GameObject prefab = Instantiate(go, GetRandomPosition(), Quaternion.identity);

        prefab.transform.SetParent(collectablesParentObject);
    }
}
