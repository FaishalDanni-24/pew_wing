using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteMovement : MonoBehaviour
{
    // Attributes
    private CameraController cam;
    private Rigidbody2D rbSat;
    private Vector2 dirVector;
    public float speed;
    private bool hasOutofBounds;
    private bool currOutofBounds;


    // Dijalankan sekali saat load script
    void Awake()
    {
        rbSat = GetComponent<Rigidbody2D>();
        dirVector = new Vector2(transform.up.x, transform.up.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    // FixedUpdate is called once per 20 ms (0.02 s)
    void FixedUpdate()
    {   
        rbSat.velocity = dirVector * speed;

        currOutofBounds = cam.IsOutofBound(transform.position);

        // Cek out of bounds (Di luar layar, saat spawn)
        if (!hasOutofBounds && currOutofBounds)
        {
           return; 
        }

        // Cek out of bounds (Di dalam layar)
        if (!hasOutofBounds && !currOutofBounds)
        {
            hasOutofBounds = true;
        }

        // Cek out of bounds (Di luar layar, telah melewati area game)
        if (hasOutofBounds && currOutofBounds)
        {
            Destroy(gameObject);
        }
    }
}
