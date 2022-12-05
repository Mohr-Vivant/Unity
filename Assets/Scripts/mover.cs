using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{

    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}