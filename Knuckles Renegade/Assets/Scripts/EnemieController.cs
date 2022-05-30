using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
    public float velocidad;
     Transform objetivo;
    public float distanciaConElObjetivo;
    public float distanciaMin;
    public bool ataque;
    public Transform pivotPunch;
    public GameObject punchCollider;
    public SpriteRenderer personaje;
    BoxCollider2D colliderPersonaje;
    public BoxCollider2D colliderPersonaje2;
    PlayerController playerController;
    public float vida;
    Animator animController;
    public bool defenceState;
    public bool defenceA;
    public bool detectado;
    public float tiempoDeDefensa;
    void Start()
    {
        objetivo = GameObject.Find("Knuckles").GetComponent<Transform>();
        animController = GetComponent<Animator>();
        //colliderPersonaje = GetComponent<BoxCollider2D>();
        //Physics2D.IgnoreCollision(colliderPersonaje, colliderPersonaje2);
        personaje = GetComponent<SpriteRenderer>();
        playerController = GameObject.Find("Main Camera").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        ControlDeVida();
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
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            }
            if (objetivo.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            }
        }
    }

    public void CalcularDistancia()
    {
        distanciaConElObjetivo = Vector2.Distance(transform.position, objetivo.transform.position);
        if(distanciaConElObjetivo<distanciaMin)
        {
            detectado = true;
            ataque = true;
            animController.SetBool("Attack",true);
        }
        else
        {
            detectado = false;
            ataque = false;
            animController.SetBool("Attack", false);
        }
    }


    public void CambiosDeEstado()
    {
        if(defenceState)
        {
            tiempoDeDefensa += 0.01f * Time.deltaTime;
            personaje.color = Color.blue;
            animController.SetBool("Attack", false);
        }

        if(tiempoDeDefensa>0.02f)
        {
            defenceState = false;
            animController.SetBool("Defence", false);
            personaje.color = Color.white;
            defenceA = true;
        }

        if(playerController.membership=="POCO" || playerController.membership == "MEDIO")
        {
            personaje.color = Color.green;
            animController.SetBool("RunP", true);
            velocidad = 6f;

        }
        else
        {
            //personaje.color = Color.red;
            animController.SetBool("RunP", false);
            velocidad = 4f;
        }

        if (defenceA == false && detectado)
        {
            if (playerController.membership2=="MUCHO")
            {
                defenceState = true;
                animController.SetBool("Defence", true);
            }
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


    public void ControlDeVida()
    {
        if(vida<=0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PunchP"))
        {
            if(defenceState==false)
            {
                vida -= 25f;
            }
           
        }
    }

    public void ActivePunch()
    {
        Instantiate(punchCollider, pivotPunch.transform.position, transform.rotation);
      
    }

    public void DeseablePunch()
    {
        
       
    }
}
