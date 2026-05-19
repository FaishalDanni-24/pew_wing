using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Attributes
    Camera cam;

    public float borderLeft, borderRight, borderTop, borderBottom;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
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
