using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float velocidad;
    void Start()
    {
        
    }

 
    void Update()
    {
        transform.Rotate(Vector3.up * velocidad * Time.deltaTime);
    }
}
