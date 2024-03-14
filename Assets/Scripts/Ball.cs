using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed ;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 hitPoint = collision.contacts[0].point;
            float paddleCenterX = collision.collider.bounds.center.x;

            float difference = hitPoint.x - paddleCenterX;
            rb.velocity = new Vector2(difference * 2f, rb.velocity.y).normalized * speed;
        }

    }
}
