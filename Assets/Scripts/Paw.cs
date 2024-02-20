using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paw : MonoBehaviour
{

    Transform myTransform; 
    Vector3 myPosition; 
    Vector3 handPos; 

    // Start is called before the first frame update
    void Start()
    {
        Transform myTransform = transform;
        Vector3 myPosition = transform.position;
        Vector3 handPos = new Vector3(0, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        handPos = FindAnyObjectByType<Gest2World>().getPos();
        transform.position = handPos; 
    }
}
