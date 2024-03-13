using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    [SerializeField] private int vida;
    public float speed = 5f;
    public Color[] colores; 
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //ActualizarColor();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            vida--;
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                ActualizarColor();
            }
        }

        if (collision.gameObject.CompareTag("Bricks"))
        {
            Vector2 hitPoint = collision.contacts[0].point;
            float paddleCenterX = collision.collider.bounds.center.x;

            float difference = hitPoint.x - paddleCenterX;
            rb.velocity = new Vector2(difference * 2f, rb.velocity.y).normalized * speed;
        }
    }

    private void ActualizarColor()
    {
        
        spriteRenderer.color = colores[vida-1];
    }
}

