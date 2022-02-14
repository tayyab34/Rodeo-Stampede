using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float xRange=19;
    private float zrange = -8;
    public GameObject animalPrefab;
    private int startDelay=2;
    private float delay = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startDelay, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Spawn()
    {
        Vector3 Position = new Vector3(Random.Range(-xRange, xRange), 0, zrange);
        Instantiate(animalPrefab, Position, animalPrefab.transform.rotation);
    }
}
