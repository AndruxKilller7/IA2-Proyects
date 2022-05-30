using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    public GameObject activeGun;
    NavMeshAgent agent;
    public GameObject enemy;
    public float distanciaParaHuir;
    public float distanciaDeArmas;
    public GameObject guns;
    public bool tomarArmas;
    public Transform pivot;
    RaycastHit hit;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    
    void Update()
    {
        Huir();
        DetectarGuns();
        PointShoot();
    }

    public void Huir()
    {
        
            float distancia = Vector3.Distance(transform.position, enemy.transform.position);

            if (distancia < distanciaParaHuir)
            {
                Vector3 direccionDelEnemigo = transform.position - enemy.transform.position;
                Vector3 nuevaPosicion = transform.position + direccionDelEnemigo;

                agent.SetDestination(nuevaPosicion);

            }
        
        
    }


    public void DetectarGuns()
    {
        if(tomarArmas==false)
        {
            float distancia = Vector3.Distance(transform.position, guns.transform.position);

            if (distancia < distanciaDeArmas)
            {
                agent.SetDestination(guns.transform.position);
            }
            
        }
       
       
    }

    public void PointShoot()
    {
        
       
    }

    private void OnDrawGizmos()
    {
        
     
        Gizmos.DrawWireSphere(transform.position, distanciaDeArmas);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(pivot.position, transform.forward * 10f);
        if (Physics.Raycast(pivot.position, Vector3.forward, out hit, 10f))
        {
            if (hit.collider.CompareTag("EnemyBody"))
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(pivot.position, transform.forward * 10f);
            }
           


        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Guns"))
        {
            activeGun.SetActive(true);
            tomarArmas = true;
            
        }
    }
}
