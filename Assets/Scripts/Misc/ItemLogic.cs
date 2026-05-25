using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLogic : MonoBehaviour
{
    // Attributes
    private CameraController cam;
    public string type;
    private float timePassed;
    private float timeToDespawn = 5;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    // FixedUpdate is called once per 20 ms (0.02 s)
    void FixedUpdate()
    {
        if(cam.IsOutofBound(transform.position, 0)){Destroy(gameObject);}
        if(timePassed > timeToDespawn){Destroy(gameObject);}
        timePassed += Time.fixedDeltaTime;
    }
}
