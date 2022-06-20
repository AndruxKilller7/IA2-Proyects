using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estequeome 
{



    public float incognita;
    public float valorQueSeTiene;
    public float coeficienteEstequeometrico1;
    public int coeficienteEstequeometrico1p;
    public int coeficienteEsteqeueometrico2;
    public int coeficienteEsteqeueometrico2p;
    public float coefiicneteEstequeometricoProducto;
    public int valencia1;
    public int valencia2;
    public int valencia1p;
    public int valencia2p;
    public int productiCoeficiente2;
    string enunciado;
    public string nameElemento1;
    public string nameElemento2;

  

    public Estequeome(float medidor, int v1,int v2,string variable1, string variable2)
    {
        valorQueSeTiene = medidor;
        valencia1 = v1;
        valencia2 = v2;
        nameElemento1 = variable1;
        nameElemento2 = variable2;
    }

    public void MostrarEcuacion()
    {
        enunciado = coeficienteEstequeometrico1+nameElemento1 +" + "+coeficienteEsteqeueometrico2+nameElemento2 + valencia2 + "-->"+coefiicneteEstequeometricoProducto +nameElemento1+valencia1p + nameElemento2+valencia2p;
        Debug.Log(enunciado);
    }

    public void BalanceoDeEcucion()
    {
        valencia1p = valencia2 ;
        valencia2p = valencia1 ;

        if(valencia1p==valencia2p)
        {
            valencia1p = valencia1p / 2;
            valencia2p = valencia2p / 2;
        }
        int aux;
        
        for(int i=0;i<10;i++)
        {
            aux = i / valencia2;
           
            if (aux==valencia2p)
            {
                Debug.Log(i);
                coeficienteEsteqeueometrico2 = i/valencia2;
                coefiicneteEstequeometricoProducto = i / valencia2p;
                break;
            }
           
        }

        coeficienteEstequeometrico1 = valencia1p * coefiicneteEstequeometricoProducto;
        


    }

    public void FormularEcuacion()
    {
        //elemento1 = elemento1 + valencia1;
        //elemento2 = elemento2 + valencia2;
        BalanceoDeEcucion();
        MostrarEcuacion();
       
        //productoDeElemento1 = valencia2*(elemento1);
        //productoDeElemento2 = valencia1 * (elemento2);
       
    }

    public float ResolverEcuacion()
    {
        incognita = valorQueSeTiene * (coefiicneteEstequeometricoProducto / coeficienteEstequeometrico1);
        Debug.Log(incognita + " mol");
        return incognita;

    }
}
