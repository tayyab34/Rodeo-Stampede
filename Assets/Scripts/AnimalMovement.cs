using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    private Rigidbody animalRb;
    public float force=1f;
    // Start is called before the first frame update
    void Start()
    {
        animalRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //AnimalMovement
        animalRb.AddForce(Vector3.back * force);
    }
}
