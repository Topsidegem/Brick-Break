using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBar : MonoBehaviour
{
    private Player controls; 
    public float speed = 5f; 
    private float moveInput;


    void Start()
    {
        controls = new Player();
        controls.Enable();

        //preguntar como funciana este codigo de chatgpt
        controls.Movement.Derecha.performed += ctx =>
        {
            moveInput = ctx.ReadValue<float>();
        };
        controls.Movement.Derecha.canceled += ctx => moveInput = 0f;

        controls.Movement.Izquierda.performed += ctx =>
        {
            moveInput = -ctx.ReadValue<float>(); 
        };
        controls.Movement.Izquierda.canceled += ctx => moveInput = 0f;
    }

    void FixedUpdate()
    {
        if (moveInput != 0)
        {
            Vector2 movement = (moveInput > 0) ? Vector2.right : Vector2.left;
            transform.Translate(movement * speed * Time.fixedDeltaTime);
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }

    void OnDisable()
    {
        controls.Disable();
    }
}


