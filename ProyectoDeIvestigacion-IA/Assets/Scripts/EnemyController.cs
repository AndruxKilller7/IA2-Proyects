using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agentEnemy;
    public Transform objetivo;
    
    void Start()
    {
        agentEnemy = GetComponent<NavMeshAgent>();
        
    }

    
    void Update()
    {
        agentEnemy.destination = objetivo.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GunBullet"))
        {
            Destroy(other.gameObject);
           
        }
    }


    
}
