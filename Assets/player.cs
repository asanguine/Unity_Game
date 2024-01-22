using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class player : MonoBehaviour {
    public float moveSpeed = 1f;
    public float jumpForce = 100f;
    private bool isGrounded;
    private float inputX;
    Animator animator;
    private Rigidbody2D rb;

    public bool isSwinging;
    public bool isInAnchorRange = false;
    private Transform hookTransform;

    [SerializeField]
    private Hook hook;


    public void makeThingsWorkAgain() {
        if (isSwinging) {
            Debug.Log("F pressed to drop");
            hook.stopSwinging();
            isSwinging = false;
        }
    }


    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hookTransform = GameObject.FindGameObjectWithTag("Anchor").transform;
    }


    void Update() {


        inputX = UnityEngine.Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(inputX));

        if(!isSwinging) {
            Vector3 movement = new Vector3(inputX, 0f, 0f);
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        }

        if (inputX > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (inputX < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space)) {
            if (isGrounded)
                rb.AddForce(new Vector2(0, 100));
            SpecialEffects.specialEffects.CreateSmoke(transform);
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.F)) {
            if (!isSwinging && isInAnchorRange) {
                Debug.Log("F pressed and in Range");
                hook.startSwinging();

            }
            else if (isSwinging) {
                Debug.Log("F pressed to drop");
                hook.stopSwinging();
            }
            else if (!isInAnchorRange) {
                Debug.Log("F pressed but not in Range");
            }
        }
    }



    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Anchor") {
            isInAnchorRange = true;
            Debug.Log("Entered Anchor Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Anchor") {
            isInAnchorRange = false;
            Debug.Log("Exited Anchor Range");
        }
    }
}
