using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agentEnemy;
    public Transform objetivo;
    public float vida;
    public GameObject efectoDestruccion;
    
    void Start()
    {
        agentEnemy = GetComponent<NavMeshAgent>();
        
    }

    
    void Update()
    {
        agentEnemy.destination = objetivo.position;
        ControlDeVida();
    }


    public void ControlDeVida()
    {
        if(vida<=0)
        {
            Destroy(this.gameObject);
            Instantiate(efectoDestruccion, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GunBullet"))
        {
            Destroy(other.gameObject);
           
        }
    }


    
}
