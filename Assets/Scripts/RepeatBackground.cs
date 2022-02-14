using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float speed = 5f;
    private float repeatwidth;
    
    void Start()
    {
        repeatwidth=GetComponent<BoxCollider>().size.x/2;
        startPos = transform.position;
    }

    
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < startPos.z - repeatwidth) 
        {
            transform.position = startPos;
        }
    }
}
