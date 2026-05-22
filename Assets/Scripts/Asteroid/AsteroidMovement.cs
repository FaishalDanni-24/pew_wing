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

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
        rbAst = GetComponent<Rigidbody2D>();
        stat = GetComponent<AsteroidStat>();

        if (stat.comet)
        {
            speed = speed * 3;
        }

        dirVector = new Vector2(transform.up.x, transform.up.y);
        rotSpeed = Random.Range(-1.0f, 1.0f) * rotSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called once per 20 ms (0.02 s)
    void FixedUpdate()
    {
        rbAst.velocity = dirVector * speed;
        rbAst.rotation += rotSpeed;
    }
}
