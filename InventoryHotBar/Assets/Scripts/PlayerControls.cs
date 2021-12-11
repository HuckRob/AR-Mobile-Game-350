using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float speed, jumpSpeed;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    private bool isOnGround = false;
    public Joystick joystick;


    void Start()
    {
        Debug.Log("Start");
        rb = GetComponent<Rigidbody>();
    }

    //Ground Detection
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    //Input Functions
    
    void FixedUpdate()
    {
        horizontalInput = joystick.Horizontal;

        Vector3 currentPosition = transform.position;
        currentPosition.x += horizontalInput * speed * Time.deltaTime;
        transform.position = currentPosition;

        verticalInput = joystick.Vertical;
        if (isOnGround && verticalInput >= 0.5f)
        {
            rb.AddForce(transform.up * jumpSpeed * 25);
            Debug.Log("Jump");
            isOnGround = false;
        }
    }
}
