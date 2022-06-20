using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacoScript : MonoBehaviour
{
    BoxerPlayer playerControl;
    public GameObject efectoCubos;
    public float controlDeTiempo;
    void Start()
    {
        playerControl = GameObject.Find("RPG-Character").GetComponent<BoxerPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControl.barraDeAciertos>=200)
        {
            controlDeTiempo += 0.1f * Time.deltaTime;

            if(controlDeTiempo>=0.6f)
            {
                Destroy(this.gameObject);
                Instantiate(efectoCubos, transform.position, transform.rotation);
            
            }
            
        }
    }
}
