using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    // Attributes
    private Rigidbody2D rbPlayer;
    private float inputX;
    private float inputY;
    public float transThrust;
    public float rotThrust;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

    // FixedUpdate is called once per 20 ms (0.02 s)
    void FixedUpdate()
    {
        rbPlayer.AddForce(transform.up * transThrust * inputY);
        rbPlayer.AddTorque(-(inputX * rotThrust));
    }
}
