using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    //private Animator animator;
    [SerializeField] float gravity = -10f;
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpForce = 15f;
    [SerializeField] float checkRadius = 0.3f;
    [SerializeField] float jumpTime = 0.1f;
    private bool IsJump;
    public LayerMask groundLayer;
    public Transform groundCheck;

    float xInput;

    bool facingRight;
    bool jump;
    bool isJumping;
    bool isGrounded;
    bool doubleJump;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
       // animator = GetComponent<Animator>();
        facingRight = true;
    }

    private void Update()
    {
        if (jump && !isJumping)
        {
            jump = false;
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(xInput * moveSpeed, rb.velocity.y, 0f);

        //flipping the player
        if (xInput < 0 && facingRight)
        {
            flipPlayer();
        }
        else if (xInput > 0 && !facingRight)
        {
            flipPlayer();
        }

        void flipPlayer()
        {
            facingRight = !facingRight;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
       
      /* if(xInput != 0)
        {
            animator.SetBool("IsMoving", true);

        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
       
      */
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);
        if(!isGrounded)
        {
            rb.velocity += new Vector3(0, gravity * Time.deltaTime, 0);
        }

        if (!isGrounded && isJumping)
        {
            isJumping = false;
            return;
        }

        if (isGrounded && isJumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
            isJumping = false;
          //  animator.SetBool("IsJump", false);
         //   IsJump = false;
        }
        
        
    }
   
    public void HorizontalInput(float value)
    {
        xInput = value;
    }

  public void JumpInput()
    {
        
        IsJump = true;
       jump = true;
      //  Jump();
       
   }
 /*void Jump()
    {
        if(isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
            isJumping = true;
            doubleJump = true;
            
        }else if(doubleJump)
        {
            rb.velocity = new Vector3(rb.velocity.x,jumpForce, 0f);
            isJumping = true;
            doubleJump = false;
        }
    }  
 */


}
