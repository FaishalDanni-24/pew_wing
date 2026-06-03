using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    // Attributes
    private CameraController cam;
    private Rigidbody2D rbAst;
    private AsteroidStat stat;
    private Vector2 dirVector;
    public float speed;
    public float rotSpeed;
    private bool hasOutofBounds;
    private bool currOutofBounds;


    // Dijalankan sekali saat load script
    void Awake()
    {
        rbAst = GetComponent<Rigidbody2D>();
        stat = GetComponent<AsteroidStat>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
        
        currOutofBounds = cam.IsOutofBound(transform.position);
        if (stat.comet)
        {
            speed = speed * 3;
        }

        dirVector = new Vector2(transform.up.x, transform.up.y);
        rotSpeed = Random.Range(-1.0f, 1.0f) * rotSpeed;
    }

    // FixedUpdate is called once per 20 ms (0.02 s)
    void FixedUpdate()
    {
        rbAst.velocity = dirVector * speed;
        if (!stat.comet)
        {
            rbAst.rotation += rotSpeed;
        }
        
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
            GameObject.Find("Spawner").GetComponent<ObjectSpawner>().AddNumSpawned(-1);
        }
    }
}
