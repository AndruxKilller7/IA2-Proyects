using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumsProyectil : MonoBehaviour
{
    public GameObject bulletGun;
    public float fireRate;
    public float nextFire;
    public bool disparar;
    void Start()
    {
        
    }

   
    void Update()
    {
        Shooting();
    }


    public void Shooting()
    {
        if(disparar)
        {
            nextFire += 0.1f + Time.deltaTime;

            if(nextFire>=fireRate)
            {
                Instantiate(bulletGun, transform.position, transform.rotation);
                nextFire = 0.0f;
            }
        }
       
    }
}
