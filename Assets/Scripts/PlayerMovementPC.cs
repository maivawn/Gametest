using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementPC : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask ground;


    Rigidbody rb;
    [SerializeField] float jumdForce = 5f;
    [SerializeField] float movementSpeed = 6f;

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
         rb.velocity = new Vector3 (horizontalInput * movementSpeed , rb.velocity.y, verticalInput *movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGround ())
        {
            jump();
        }
        void jump()
        {
            rb.velocity = new Vector3(rb.velocity.x, jumdForce, rb.velocity.z);
            jumpSound.Play();       
        }

        bool IsGround()
        {
            return Physics.CheckSphere(groundCheck.position, .3f, ground);

        }

    }

    
}
