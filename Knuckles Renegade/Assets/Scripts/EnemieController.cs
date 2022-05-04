using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
    public float velocidad;
    public Transform objetivo;
    public float distanciaConElObjetivo;
    public float distanciaMin;
    public bool ataque;
    public SpriteRenderer personaje;
    BoxCollider2D colliderPersonaje;
    public BoxCollider2D colliderPersonaje2;
    PlayerController playerController;
    void Start()
    {
        //colliderPersonaje = GetComponent<BoxCollider2D>();
        //Physics2D.IgnoreCollision(colliderPersonaje, colliderPersonaje2);
        personaje = GetComponent<SpriteRenderer>();
        playerController = GameObject.Find("Main Camera").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        //transform.Translate(Vector2.left * velocidad * Time.deltaTime);
        CalcularDistancia();
        Persecucion();
        CambiosDeEstado();

        



    }

    public void Persecucion()
    {
        if (ataque == false)
        {
            if (objetivo.position.x > transform.position.x)
            {
                transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            }
            if (objetivo.position.x < transform.position.x)
            {
                transform.Translate(Vector3.left * velocidad * Time.deltaTime);
            }
        }
    }

    public void CalcularDistancia()
    {
        distanciaConElObjetivo = Vector2.Distance(transform.position, objetivo.transform.position);
        if(distanciaConElObjetivo<distanciaMin)
        {
            ataque = true;
        }
        else
        {
            ataque = false;
        }
    }


    public void CambiosDeEstado()
    {
        if(playerController.life<50f)
        {
            personaje.color = Color.green;
            velocidad = 6f;
        }
        else
        {
            personaje.color = Color.red;
            velocidad = 4f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ataque");
            //Destroy(this.gameObject);

        }
    }
}
