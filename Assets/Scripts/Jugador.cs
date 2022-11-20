using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float rapidezDesplazamiento = 10f;
    public AudioSource pasos;
    private bool Hactivo;
    private bool Vactivo;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
        if (Input.GetButtonDown("Horizontal")) 
        {
            Hactivo= true;
            pasos.Play();

        }
        
        if (Input.GetButtonDown("Vertical")) 
        {
            Vactivo= true;
            pasos.Play();
        }
       
        if (Input.GetButtonUp("Horizontal")) 
        {
            Hactivo = false;
            if (Vactivo == false) 
            { 
             pasos.Pause();
            }
            
        }
       
        if (Input.GetButtonUp("Vertical"))
        {
            Vactivo = false;
            if (Hactivo == false)
            {
                pasos.Pause();
            }
        }
    }
    
} 