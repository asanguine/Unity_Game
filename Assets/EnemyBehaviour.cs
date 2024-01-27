using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private float speed;
    private int moveDirection;
    public LayerMask passThroughLayers;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        speed = 10f;
        moveDirection = 1;
    }
    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(Time.deltaTime *
        moveDirection * speed, rigidbody.velocity.y);
    }
    

    public void FlipMoveDirection()
    {
        moveDirection *= (-1);
        if (moveDirection < 0)
        {
            gameObject.GetComponent<Transform>().rotation =
            Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else if (moveDirection > 0)
        {
            gameObject.GetComponent<Transform>().rotation =
            Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (passThroughLayers == (passThroughLayers | (1 << collision.gameObject.layer))) {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}
