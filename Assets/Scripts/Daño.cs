
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Da�o : MonoBehaviour
{
    public GameObject[] Muerto;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(Muerto[Random.Range(0, Muerto.Length)]);

        }

    }

}
