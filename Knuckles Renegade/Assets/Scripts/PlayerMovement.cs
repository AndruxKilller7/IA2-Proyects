using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad;
    public float fuerzaDeSalto;
    Vector2 move;
    public PlayerControls inputs;
    PlayerController controller;
    Rigidbody2D rigPersonaje;
    public bool tocandoSuelo;

    void Start()
    {
        controller = GameObject.Find("Main Camera").GetComponent<PlayerController>();
        rigPersonaje = GetComponent<Rigidbody2D>();
        PlayerControls inputs = new PlayerControls();
        inputs.Enable();
        inputs.Controller.Movement.performed += ctx => Move(ctx.ReadValue<float>());
        inputs.Controller.Movement.canceled += ctx => StopMove();
        inputs.Controller.Jump.performed += ctx => Jump();
    }

   
    void Update()
    {
        if (move.x > 0)
        {
            transform.Translate(Vector2.right * move.x * velocidad * Time.deltaTime);
        }
        if (move.x < 0)
        {
            transform.Translate(Vector2.right * move.x * velocidad * Time.deltaTime);
        }
    }

    public void Move(float value)
    {
        move.x = value;
        
    }

    public void StopMove()
    {
        move.x = 0f;
    }

    public void Jump()
    {
        if(tocandoSuelo)
        {
            tocandoSuelo = false;
            rigPersonaje.AddForce(Vector2.up * fuerzaDeSalto , ForceMode2D.Impulse);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemie"))
        {
            controller.life -= 5f;
            controller.VerConjuntoDifuso();
        }

        if(collision.gameObject.CompareTag("Piso"))
        {
            tocandoSuelo = true;
        }
    }

   
}
