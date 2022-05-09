using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad;
    public float fuerzaDeSalto;
    Vector2 move;
    Animator animCharacter;
    public PlayerControls inputs;
    PlayerController controller;
    Rigidbody2D rigPersonaje;
    public bool tocandoSuelo;
    public int combo=1;
    public bool ataque;
    public GameObject punchCollider;
    public Transform pivotPunch;
    void Start()
    {
        animCharacter = GetComponent<Animator>();
        controller = GameObject.Find("Main Camera").GetComponent<PlayerController>();
        rigPersonaje = GetComponent<Rigidbody2D>();
        PlayerControls inputs = new PlayerControls();
        inputs.Enable();
        inputs.Controller.Movement.performed += ctx => Move(ctx.ReadValue<float>());
        inputs.Controller.Movement.canceled += ctx => StopMove();
        inputs.Controller.Jump.performed += ctx => Jump();
        inputs.Controller.Punch.performed += ctx => PunchAttack();
    }

   
    void Update()
    {
        if (move.x > 0)
        {
            animCharacter.SetBool("Run", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector2.right * move.x * velocidad * Time.deltaTime);
        }
        if (move.x < 0)
        {
            animCharacter.SetBool("Run", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector2.left * move.x * velocidad * Time.deltaTime);
        }
    }

    public void PunchAttack()
    {
       
        if(!ataque)
        {
            ataque = true;
            Instantiate(punchCollider, pivotPunch.position, transform.rotation);
            animCharacter.SetTrigger("P" + combo);
           
        }
       
      
    }

    public void StartCombo()
    {
        ataque = false;
        if (combo < 2)
        {
            combo++;
        }
    }

    public void FinishCombo()
    {
        ataque = false;
        combo = 1;
    }

    public void Move(float value)
    {
        move.x = value;
        
    }

    public void StopMove()
    {
        animCharacter.SetBool("Run", false);
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
            //controller.life -= 5f;
            //controller.VerConjuntoDifuso();
        }

        if(collision.gameObject.CompareTag("Piso"))
        {
            tocandoSuelo = true;
        }

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Punch"))
        {
            controller.life -= 5f;
            controller.angry += 9f;
            controller.VerConjuntoDifuso();
        }
    }

   


}
