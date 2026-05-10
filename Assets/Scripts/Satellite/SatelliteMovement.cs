using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SatelliteMovement : MonoBehaviour
{
    // Attributes
    private Rigidbody2D rbSat;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rbSat = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called once per 20 ms (0.02 s)
    void FixedUpdate()
    {
        Vector2 dirVector = new Vector2(transform.up.x, transform.up.y);
        rbSat.velocity = dirVector * speed;
    }
}
