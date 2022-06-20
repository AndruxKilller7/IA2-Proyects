using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPunch : MonoBehaviour
{
    BoxerPlayer playerControl;
    void Start()
    {
        playerControl = GameObject.Find("RPG-Character").GetComponent<BoxerPlayer>();
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("BagBox"))
        {
            if(playerControl.combos==0)
            {
                playerControl.barraDeAciertos += playerControl.fuerzaDeGolpe1;
            }

            if(playerControl.combos==1)
            {
                playerControl.barraDeAciertos += playerControl.fuerzaDeGolpe2;
            }

            if(playerControl.combos==2)
            {
                playerControl.barraDeAciertos += playerControl.fuerzaDeGolpe3;
            }
        }
    }
}
