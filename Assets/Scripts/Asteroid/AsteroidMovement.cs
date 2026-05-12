using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    // Attributes
    private Rigidbody2D rbAst;
    public Boolean comet;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rbAst = GetComponent<Rigidbody2D>();
        if (comet)
        {
            speed = speed * 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called once per 20 ms (0.02 s)
    void FixedUpdate()
    {
        Vector2 dirVector = new Vector2(transform.up.x, transform.up.y);
        rbAst.velocity = dirVector * speed;
    }
}
