using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Attributes
    Camera cam;
    public float borderLeft, borderRight, borderTop, borderBottom;


    // Cek apakah gameObject diluar dari layar
    public bool IsOutofBound(Vector3 position)
    {
        if (position.x < borderLeft || position.x > borderRight)
        {
            return true;
        }
        if (position.y < borderBottom || position.y > borderTop)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Dijalankan sekali saat load script
    void Awake()
    {
        cam = GetComponent<Camera>();
        borderLeft = cam.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x;
        borderRight = cam.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x;
        borderTop = cam.ViewportToWorldPoint(new Vector3(0.5f, 1, 0)).y;
        borderBottom = cam.ViewportToWorldPoint(new Vector3(0.5f, 0, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        // Nilai koordinat dunia dari batas layar
        borderLeft = cam.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x;
        borderRight = cam.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)).x;
        borderTop = cam.ViewportToWorldPoint(new Vector3(0.5f, 1, 0)).y;
        borderBottom = cam.ViewportToWorldPoint(new Vector3(0.5f, 0, 0)).y;
    }
}
