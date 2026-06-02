using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Attributes
    private Rigidbody2D rbPlayer;
    private Animator animPlayer;
    private float inputX;
    private float inputY;
    public float transThrust;
    public float rotThrust;

    // Method untuk player movement
    bool CheckMovement()
    {
        if (inputY != 0)
        {
            return true;
        }
        return false;
    }
    void MovementAnimate()
    {
        if (CheckMovement())
        {
            animPlayer.SetBool("Moving", true);
        }
        else
        {
            animPlayer.SetBool("Moving", false);
        }
    }

    // Dijalankan sekali saat load script
    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        MovementAnimate();
    }

    // FixedUpdate is called once per 20 ms (0.02 s)
    void FixedUpdate()
    {
        rbPlayer.AddForce(transform.up * transThrust * inputY);
        rbPlayer.AddTorque(-(inputX * rotThrust));
    }
}
