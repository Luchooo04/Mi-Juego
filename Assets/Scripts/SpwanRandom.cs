using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
        public GameObject susto;
        public Transform[] spawnPoints;
        public float TiempoCambiodePosicion = 2.0f;
        public float timer = 0.0f;
    
        
    void Start()
    {
        
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) 
        {
            spawnPoints[i] = transform.GetChild(i);
        }
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= TiempoCambiodePosicion) 
        {
            RandomSpawnn();
            timer = 0.0f;
            

        }
        
    }

    void RandomSpawnn() 
    {
        susto.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        

    }

   /* void LateUpdate() 
    {
        if (gameObject != null) 
        {
            Destroy(gameObject);
        
        }
    
    }
   
    */
}
