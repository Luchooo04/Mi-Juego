using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.Input;

public class CamaraFPS : MonoBehaviour
{
    private Transform camera; 
    public Vector2 sensibility;
    
    void Start()
    {
        camera = transform.Find("Main Camera");
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse y");
        if (hor != 0) 
        {
            transform.Rotate(Vector3.up * hor * sensibility.x);
        
        }
        if (ver != 0) 
        {
            camera.Rotate(Vector3.left * ver * sensibility.y);
        }
    }
}
