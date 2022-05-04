using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image barLife;
    public float life;
    void Start()
    {
        VerConjuntoDifuso();
    }

    
    void Update()
    {

        LifeController();

        
    }


    void LifeController()
    {
        life = Mathf.Clamp(life, 0, 100);
        barLife.fillAmount = life / 100;

    }

    public void VerConjuntoDifuso()
    {
        ConjuntosDifusos controller = new ConjuntosDifusos(life);
        Debug.Log(controller.Analysis());
        Debug.Log(controller.memb1);
        Debug.Log(controller.memb2);
        Debug.Log(controller.memb3);
    }

   
}
