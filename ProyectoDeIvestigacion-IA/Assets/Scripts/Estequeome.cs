using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estequeome : MonoBehaviour
{

    public float velocidad;
    public float distaciaParaHuir;
    public int elemento1;
    public int elemento2;
    public int productoDeElemento1;
    public int productoDeElemento2;
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
    string enunciado;
    public string nameElemento1;
    public string nameElemento2;

    void Start()
    {
        BalanceoDeEcucion();
        MostrarEcuacion();
        FormularEcuacion();
    }

 
    void Update()
    {
  
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

        incognita = valorQueSeTiene * (coeficienteEstequeometrico1 / coefiicneteEstequeometricoProducto);
        Debug.Log(incognita+" mol");
        //productoDeElemento1 = valencia2*(elemento1);
        //productoDeElemento2 = valencia1 * (elemento2);
       
    }
}
