using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float velocidadDeMovimiento;
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * velocidadDeMovimiento * Time.deltaTime);
    }
}
