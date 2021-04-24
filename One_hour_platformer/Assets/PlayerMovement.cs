using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpPower;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public Transform RespawnPoint;
    
    public Animator anim;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float horizontalMovement = Input.GetAxisRaw("Horizontal");


        rb.velocity = new Vector2(movementSpeed * horizontalMovement, rb.velocity.y);
        

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 && isGrounded)
            anim.SetTrigger("Walk");
        else if(isGrounded)
            anim.SetTrigger("Idle");
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }


        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            rb.velocity = Vector2.up * jumpPower;
        }
    }

    public void ResetPlayer()
    {
        rb.velocity = Vector2.zero;
        transform.position = RespawnPoint.position;
    }
}
