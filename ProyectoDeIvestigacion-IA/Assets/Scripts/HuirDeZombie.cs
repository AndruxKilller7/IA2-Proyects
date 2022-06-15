using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HuirDeZombie : MonoBehaviour
{
    public Transform zombie;
    public float distanciaLimite;
    public float velocidadDeMovimineto;
    public Animator anim;
    public NavMeshAgent agent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed=velocidadDeMovimineto;
    }


    public void ControlDeDistancia()
    {
        float distanciaAux = Vector3.Distance(transform.position, zombie.position);

        Vector3 direccionDelEnemigo = transform.position - zombie.transform.position;
        Vector3 nuevaPosicion = transform.position + direccionDelEnemigo;

        agent.SetDestination(nuevaPosicion);


    }
}
