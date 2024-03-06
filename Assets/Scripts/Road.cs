using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public float roadLength = 300f;
    public GameObject box;
    public GameObject coin;
    public Transform car;

    private GameObject currentRoad;
    private GameObject nextRoad;

    private void Start()
    {
        currentRoad = Instantiate(roadPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        nextRoad = Instantiate(roadPrefab, new Vector3(0, 0, 100f), Quaternion.identity);           
    }

    private void Update()
    {
        if (car.position.z > currentRoad.transform.position.z+ 30f + roadLength / 2)
        {
            Destroy(currentRoad);
            SpawnRoad();
        }
    }

    private void SpawnRoad()
    {
        currentRoad = nextRoad;
        nextRoad = Instantiate(roadPrefab, new Vector3(0, 0, roadPrefab.transform.position.z + 100f), Quaternion.identity);        
        roadPrefab = nextRoad;
    }

}
