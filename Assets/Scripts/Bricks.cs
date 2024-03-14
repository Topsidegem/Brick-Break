using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bricks : MonoBehaviour
{
    static bool isActive = false;
    [SerializeField] private int vida;
    [SerializeField] private float speed;
    [SerializeField] private float tiempoParaDesactivar;
    public Color[] colores;
    public BoxCollider2D box;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public GameObject BarraPowerUp;
    public int points;
    public TextMeshPro puntos;  

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            vida--;
            if (vida <= 0)
            {
                if (!isActive)
                {
                    PowerUpUno();
                }
                
                SumarPuntos();
                box.enabled = false;
                spriteRenderer.enabled = false;
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

    public void PowerUpUno()
    {
        if (Random.Range(1, 20) >= 15)
        {
            isActive = true;
            BarraPowerUp.SetActive(true);
            Invoke("DesactivarPowerUp", tiempoParaDesactivar);

        }
    }

    private void DesactivarPowerUp()
    {
        print("sis");
        BarraPowerUp.SetActive(false);
        isActive = false;
    }

    public void SumarPuntos()
    {
        points ++;
        //puntos = "Puntuacion: " + points;
    }
}

