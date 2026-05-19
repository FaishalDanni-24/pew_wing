using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    // Attributes
    CameraController cam;
    float destroyBufferDistance = 3;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Hapus laser dari scene, jika keluar layar. Diberikan jarak tambahan sebelum hapus
        if (transform.position.x < cam.borderLeft - destroyBufferDistance || transform.position.x > cam.borderRight + destroyBufferDistance)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < cam.borderBottom - destroyBufferDistance || transform.position.y > cam.borderTop + destroyBufferDistance)
        {
            Destroy(gameObject);
        }
    }
}
