using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public Transform objetivo;
    public float Velocidad;
    public NavMeshAgent IA;


    void Update()
    {
        IA.speed = Velocidad;
        IA.SetDestination(objetivo.position);

    }
}
