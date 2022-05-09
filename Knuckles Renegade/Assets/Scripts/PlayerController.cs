using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image barLife;
    public Image barAngry;
    public float life;
    public float angry;
    void Start()
    {
        VerConjuntoDifuso();
        VerConjuntoDifuso2();
    }

    
    void Update()
    {

        LifeController();

        
    }


    void LifeController()
    {
        life = Mathf.Clamp(life, 0, 100);
        barLife.fillAmount = life / 100;

        angry = Mathf.Clamp(angry, 0, 100);
        barAngry.fillAmount = angry / 100;

    }

    public void VerConjuntoDifuso()
    {
        ConjuntosDifusos controller = new ConjuntosDifusos(life);
        Debug.Log(controller.Analysis());
        Debug.Log(controller.memb1);
        Debug.Log(controller.memb2);
        Debug.Log(controller.memb3);
    }

    public void VerConjuntoDifuso2()
    {

        ConjuntosDifusos controller = new ConjuntosDifusos(angry);
        Debug.Log(controller.Analysis());
        Debug.Log(controller.memb1);
        Debug.Log(controller.memb2);
        Debug.Log(controller.memb3);

    }

   
}
