using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemie;
    public int cantidad;
    public bool spawnActive;
    public float tiempoDeSpawn;
    public Transform[] points;
    void Start()
    {
       
    }

   
    void Update()
    {
        if(cantidad<15)
        {
            tiempoDeSpawn += 0.01f*Time.deltaTime;
            if(tiempoDeSpawn>=0.02f)
            {
                SpawnSystem();
            }
           
        }
        
    }

    void SpawnSystem()
    {
        cantidad += 1;
        Debug.Log("AÑA");
        Instantiate(enemie, points[Random.Range(0, 2)].position, points[Random.Range(0, 2)].rotation);
        tiempoDeSpawn = 0.0f;
       

    }

    
}
