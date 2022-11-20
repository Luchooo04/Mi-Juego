using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public Light luzLinterna;
    public bool activLight;
    public AudioSource boton;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            activLight = !activLight;
            if (activLight == true) 
            { 
             luzLinterna.enabled = true;
            }
            if (activLight == false) 
            { 
             luzLinterna.enabled=false;
            }
        }
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            boton.Play();
        }

        if (Input.GetKeyUp(KeyCode.F)) 
        {
            boton.Pause();
        }
    }
}
