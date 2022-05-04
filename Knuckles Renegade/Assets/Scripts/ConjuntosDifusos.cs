using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConjuntosDifusos 
{

    public string terminoLinguistico = "POCO";
    public string terminoLinguistico2 = "MEDIO";
    public string terminoLinguistico3 = "MUCHO";
    public float memb1;
    public float memb2;
    public float memb3;
   

    public ConjuntosDifusos(float x)
    {
        memb1 = FuncionDeInicio(x, 20f, 35f);
        memb2 = FuncionNormal(x, 20f, 40f, 60f, 80f);
        memb3 = FuncionFinal(x, 55f, 80f);
    }



    public string Analysis()
    {
        float eval1;
        float eval2;
        float eval3;
        string resultado = " ";

        Dictionary<string, float> Eval = new Dictionary<string, float>();
        Eval.Add(terminoLinguistico, memb1);
        Eval.Add(terminoLinguistico2, memb2);
        Eval.Add(terminoLinguistico3, memb3);

        eval1 = (ReglaOR(Eval[terminoLinguistico], Eval[terminoLinguistico2]));
        eval2=  (ReglaOR(Eval[terminoLinguistico2], Eval[terminoLinguistico3]));
        eval3 = (ReglaOR(eval1,eval2));

        foreach (var p in Eval)
        {
            if(p.Value == eval3)
            {
                resultado = p.Key;
            }
        }
        return resultado;
    }

    public float FuncionDeInicio(float x, float a, float b)
    {
        float membership = 0f;
        if(x<=a)
        {
            membership = 1f;
        }

        if(x>a && x<b)
        {
            membership = ((b - x) / (b - a));

        }

        if(x>=b)
        {
            membership = 0f;
        }

        return membership;
    }


    public float FuncionFinal(float x, float a, float b)
    {
        float membership = 0f;

        if (x <= a)
        {
            membership = 0f;
        }

        if (x > a && x < b)
        {
            membership = ((x - a) / (b - a));

        }

        if (x >= b)
        {
            membership = 1f;
        }

        return membership;
    }

    public float FuncionNormal(float x, float a, float b, float c,float d)
    {
        float membership = 0f;

        if (x <= a)
        {
            membership = 0f;
        }

        if (x > a && x < b)
        {
            membership = ((x - a) / (b - a));

        }
        if (x >= b && x <= c)
        {
            membership = 1f;

        }
        if (x > c && x < d)
        {
            membership = ((d - x) / (d - c));

        }

        if (x >= c)
        {
            membership = 0f;
        }

        return membership;
    }


    public float ReglaAND(float a, float b)
    {
        return Mathf.Min(a, b);
    }

    public float ReglaOR(float a, float b)
    {
        return Mathf.Max(a, b);
    }

}
