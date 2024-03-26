using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementPC : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask ground;
    public float gravity;
    bool IsGround;
    Rigidbody rb;
    [SerializeField] float jumdForce = 5f;
    [SerializeField] float movementSpeed = 6f;

    // [SerializeField] AudioSource jumpSound;
    Controller controller;

    private void Awake()
    {
        controller = new Controller();
        controller.Enable();
        controller.cotroller.Jump.performed += ctx => jump();
    }
    void Start()
    {
      
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Movemement();
        IsGround = Physics.CheckSphere(groundCheck.position, .3f, ground);

    }
    

    public void jump()
    {
        if (IsGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumdForce, rb.velocity.z);
        }
        if(!IsGround)
        {
            rb.velocity -= new Vector3(rb.velocity.x, gravity*Time.deltaTime, rb.velocity.z);
        }



        //jumpSound.Play();       
    }
    public void Movemement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
    }
}
