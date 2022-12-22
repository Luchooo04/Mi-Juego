using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Linterna : MonoBehaviour
{
    public Light luzLinterna;   
    public bool activLight;
    public AudioSource boton;
    public float cantBateria = 100;
    public float perdidaBateria = 0.5f;

    [Header("Visuales")]
    public Image pila1;
    public Image pila2;
    public Image pila3;
    public Image pila4;
    public Sprite pilaVacia;
    public Sprite pilaLlena;
    public Text porcentaje;


    void Update()
    {

        cantBateria = Mathf.Clamp(cantBateria, 0, 100);
        int valorBateria = (int)cantBateria;
        porcentaje.text = valorBateria.ToString() + "%";



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
        if (activLight == true && cantBateria > 0)
        {
            cantBateria -= perdidaBateria * Time.deltaTime;
        }

        if (cantBateria == 0)
        {
            luzLinterna.intensity = 0f;
            pila1.sprite = pilaVacia;
        }

         if (cantBateria > 0 && cantBateria <= 25)
        {
            luzLinterna.intensity = 150f;
            pila1.sprite = pilaLlena;
            pila2.sprite = pilaVacia;
        }

         if (cantBateria > 25 && cantBateria <= 50)
        {
            luzLinterna.intensity = 300f;
            pila2.sprite = pilaLlena;
            pila3.sprite = pilaVacia;
        }

         if (cantBateria > 50 && cantBateria <= 75)
        {
            luzLinterna.intensity = 600f;
            pila3.sprite = pilaLlena;
            pila4.sprite = pilaVacia;
        }

         if (cantBateria > 75 && cantBateria <= 100)
        {
            luzLinterna.intensity = 900f;
            pila4.sprite = pilaLlena;
        }
        /*
         (Input.GetKeyDown(KeyCode.F)) 
        {
            boton.Play();
        }

        if (Input.GetKeyUp(KeyCode.F)) 
        {
            boton.Pause();
        }
        */
    }
}
