using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estequeometria : MonoBehaviour
{

    public float elemento1;
    public float elemento2;
    public float factorMolar1;
    public float factorMolar2;
    public float producto1;
    public float producto2;
    public float producto3;
    public float ecuacion;
    public float coeficienteEstequeometrico1;
    public float coeficienteEstequeometrico2;
    public float coeficienteEstequeometricoProducto;
    public bool estaBalanceado;
    public string enunciado;
    public float resultado;
    public float resultadoEsperado = 5.27f;
    void Start()
    {
        enunciado = "¿Cuantas MOL de aluminio son necesarios para producir " + resultadoEsperado+" mol de Oxido de Aluminio";
        Debug.Log(enunciado);

    }

  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Balanceo();
            FormularEcuacion();
        }
    }


    public void Balanceo()
    {
        factorMolar1 = elemento1;
        factorMolar2 = elemento2;
        factorMolar1 = (factorMolar1 % 2);
        factorMolar2 = (factorMolar2 % 2);

        if (factorMolar1==0)
        {
            coeficienteEstequeometrico1 = 3;
        }
        else if(factorMolar1==1)
        {
            coeficienteEstequeometrico1 = 2;
        }

        if(factorMolar2==0)
        {
            coeficienteEstequeometrico2 = 3;
        }
        else if(factorMolar2 == 1)
        {
            coeficienteEstequeometrico2 = 2;
        }

        Debug.Log(elemento1 + " : " + coeficienteEstequeometrico1);
        Debug.Log(elemento2 + " : " + coeficienteEstequeometrico2);

    }

    public void FormularEcuacion()
    {
        //ecuacion =  (coeficienteEstequeometrico1*elemento1) + (coeficienteEstequeometrico2*elemento2);
        resultado = (coeficienteEstequeometrico1*2)*producto1 / (coeficienteEstequeometrico2-1)*producto2;
        resultado = resultadoEsperado * resultado;
        Debug.Log(resultado);

    }
}
