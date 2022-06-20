using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AndruDecisionMakingSystem : MonoBehaviour
{


    public float distanciaDeDeteccion;
    public float distanciaDeDeteccionAtaque;
    public float fuerzaDeSalto;
    public float velocidadDeMovimiento;
    NavMeshAgent agent;
    public GameObject enemigo;
    public GameObject cerca;
    public float distanciaInicial;
    public float distanciaInicialDeAtaque;
    Rigidbody rb;
    public Animator anim;
    public bool escapar;
    public bool salto;
    public GameObject[] cubes;
    public int contadorDeCubos;
    public int indiceCubos;
    public float controladorDeDistanci;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Force);
        agent = GetComponent<NavMeshAgent>();
        distanciaInicial = Vector3.Distance(transform.position, enemigo.transform.position);
    
        Estequeome medidorParaHuir = new Estequeome(distanciaInicial, 3, 2,"D","V");
        medidorParaHuir.FormularEcuacion();
        distanciaDeDeteccion = medidorParaHuir.ResolverEcuacion();
     

    }

 
    void Update()
    {
        FijarObjetivo();
        Huir();
        if (agent.remainingDistance == 0)
        {
            anim.SetFloat("Blend", 0);
        }
        //Jump();
    }


    public void FijarObjetivo()
    {
        //if(escapar==false)
        //{
        //    agent.destination = cubes[indiceCubos].transform.position;
        //}
    }


    public void Huir()
    {
      
        float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
        controladorDeDistanci = distancia;

        if (distancia <= distanciaDeDeteccion)
        {
            //agent.speed = 8f;
            escapar = true;
            anim.SetFloat("Blend", 1);
            Vector3 direccionDelEnemigo = transform.position - enemigo.transform.position;
            Vector3 nuevaPosicion = transform.position + direccionDelEnemigo;
          
            agent.SetDestination(nuevaPosicion);
        }
        else
        {
            anim.SetFloat("Blend", 0);
        
        //escapar = false;
        }




    }


    public void Jump()
    {
        float distancia = Vector3.Distance(transform.position, cerca.transform.position);

        if (distancia <= distanciaDeDeteccionAtaque)
        {

            

            rb.AddForce(new Vector3(0, 1, 1) * fuerzaDeSalto, ForceMode.Force);

            Debug.Log("salto");


        }
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("CuboR"))
        {
            contadorDeCubos += 1;
            Destroy(collision.gameObject);
            indiceCubos += 1;
        }
    }



}
