using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class player : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpForce = 10f;
    private bool isGrounded;
    private float inputX;
    Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = UnityEngine.Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(inputX));

        isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Ground"));


        Vector3 movement = new Vector3(inputX, 0f, 0f);
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);


        if (inputX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (inputX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (isGrounded && UnityEngine.Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

    }
}
