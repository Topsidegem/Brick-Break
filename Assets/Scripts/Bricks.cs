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
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public GameObject BarraPowerUp;
    public int points;
    public TextMeshPro puntos;  

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
                if (!isActive)
                {
                    PowerUpUno();
                }
                
                SumarPuntos();
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

    public void PowerUpUno()
    {
        if (Random.Range(1, 10) >= 2)
        {
            isActive = true;
            BarraPowerUp.SetActive(true);
            Invoke("DesactivarPowerUp", tiempoParaDesactivar);
            //StartCoroutine("DesactivarPowerUpDespuesDeTiempo");

        }
    }

    private void DesactivarPowerUp()
    {
        print("sis");
        BarraPowerUp.SetActive(false);
        isActive = false;
    }

    //private IEnumerator DesactivarPowerUpDespuesDeTiempo()
    //{
    //    print("si jalo la corrutina");
    //    BarraPowerUp.SetActive(false);
    //    yield return new WaitForSeconds(1f);
    //}

    public void SumarPuntos()
    {
        points ++;
        //puntos = "Puntuacion: " + points;
    }
}

