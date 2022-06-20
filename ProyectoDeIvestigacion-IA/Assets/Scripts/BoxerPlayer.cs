using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxerPlayer : MonoBehaviour
{

    public Text porcentajeDeAciertos;
    public float combos;
    public float barraDeAciertos;
    public float tiempoDeGolpe;
    public float tiempoMaximo;
    public float controlDeTiempo;
    public Animator anim;
    public Image barra;
    public float fuerzaDeGolpe1;
    public float fuerzaDeGolpe2;
    public float fuerzaDeGolpe3;
    public float fuerzaMaxima;
    public float disminucionDeTiempo;
    public bool destruido;
    public int contadorDeGolpes;
    public float tD;
    public float indiceDeCombo;
    public float intervaloDeBarraBajo;
    public float intervaloDeBarraMedio;
    public float intervaloDeBarraAlto;
    void Start()
    {
        //Calcular Intervalo de tiempo normal por cada golpe
        Estequeome medidorDeTiempo = new Estequeome(tiempoMaximo, 3, 2, "T", "L");
        medidorDeTiempo.FormularEcuacion();
        tiempoDeGolpe = medidorDeTiempo.ResolverEcuacion();

        //Calcular fuerza de golpe fuerte
        Estequeome medidorDeFuerza3 = new Estequeome(fuerzaMaxima, 2, 2, "F", "L");
        medidorDeFuerza3.FormularEcuacion();
        fuerzaDeGolpe3 = medidorDeFuerza3.ResolverEcuacion();

        //Calcular fuerza de golpe medio
        Estequeome medidorDeFuerza2 = new Estequeome(fuerzaMaxima, 3, 2, "F", "L");
        medidorDeFuerza2.FormularEcuacion();
        fuerzaDeGolpe2 = medidorDeFuerza2.ResolverEcuacion();

        //Calcular fuerza de golpe simple
        Estequeome medidorDeFuerza1 = new Estequeome(fuerzaMaxima, 1, 3, "F", "L");
        medidorDeFuerza1.FormularEcuacion();
        fuerzaDeGolpe1 = medidorDeFuerza1.ResolverEcuacion();

        //Calcular intervalo de barra 1
        Estequeome medidorDeIntervaloB1 = new Estequeome(200, 3, 2, "L", "T");
        medidorDeIntervaloB1.FormularEcuacion();
        intervaloDeBarraAlto = medidorDeIntervaloB1.ResolverEcuacion();

        //Calcular intervalo de barra 2
        Estequeome medidorDeIntervaloB2 = new Estequeome(200, 1, 3, "L", "T");
        medidorDeIntervaloB2.FormularEcuacion();
        intervaloDeBarraMedio = medidorDeIntervaloB2.ResolverEcuacion();

        //Calcular intervalo de barra 3
        Estequeome medidorDeIntervaloB3 = new Estequeome(200, 1, 6, "L", "T");
        medidorDeIntervaloB3.FormularEcuacion();
        intervaloDeBarraBajo = medidorDeIntervaloB3.ResolverEcuacion();

    }


    void Update()
    {
        barraDeAciertos = Mathf.Clamp(barraDeAciertos, 0, 200);
        barra.fillAmount = barraDeAciertos / 200;
        porcentajeDeAciertos.text = barraDeAciertos.ToString() + "%";
        if (destruido == false)
        {
            Golpear();
        }
          
        ControlDeBarra();
    }

    public void Golpear()
    {
       
            controlDeTiempo += 0.1f * Time.deltaTime;
            if (controlDeTiempo >= tiempoDeGolpe)
            {
                tiempoDeGolpe -= disminucionDeTiempo;
                anim.SetTrigger("P" + combos);
                controlDeTiempo = 0.0f;
                
              
            }

            
        
        
    } 

    public void ControlDeBarra()
    {
        if(barraDeAciertos>=200f)
        {
            destruido = true;
        }

        if(destruido==false)
        {
            if (barraDeAciertos >= intervaloDeBarraBajo)
            {
               
                //Calcular Intervalo de tiempo normal por cada golpe
                Estequeome medidorDeAumentoDeIntervaloDeTiempo = new Estequeome(tiempoDeGolpe, 3, 2, "T", "L");
                medidorDeAumentoDeIntervaloDeTiempo.FormularEcuacion();
                tiempoDeGolpe = medidorDeAumentoDeIntervaloDeTiempo.ResolverEcuacion();
            }
            if (barraDeAciertos >= intervaloDeBarraMedio)
            {
                barra.color = Color.yellow;
                combos = 1;
                //Calcular Intervalo de tiempo normal por cada golpe
                Estequeome medidorDeAumentoDeIntervaloDeTiempo = new Estequeome(tiempoDeGolpe, 3, 2, "T", "L");
                medidorDeAumentoDeIntervaloDeTiempo.FormularEcuacion();
                tiempoDeGolpe = medidorDeAumentoDeIntervaloDeTiempo.ResolverEcuacion();
            }
            if (barraDeAciertos >= intervaloDeBarraAlto)
            {
                barra.color = Color.green;
                combos = 2;
                //indiceDeCombo = 2f;
                //Calcular Intervalo de tiempo normal por cada golpe
                Estequeome medidorDeAumentoDeIntervaloDeTiempo = new Estequeome(tiempoDeGolpe, 3, 2, "T", "L");
                medidorDeAumentoDeIntervaloDeTiempo.FormularEcuacion();
                tiempoDeGolpe = medidorDeAumentoDeIntervaloDeTiempo.ResolverEcuacion();
            }
        }

      
    }


}
