using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float rapidezDesplazamiento = 10f;
    public float SprintDesplazamiento = 20f;
    public AudioSource pasos;
    private bool Hactivo;
    private bool Vactivo;
    private int cont;
    public TMPro.TMP_Text textoCantidadRecolectados;
    public TMPro.TMP_Text textoGanaste;
    public CapsuleCollider col;
 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        col = GetComponent<CapsuleCollider>();
        cont = 0;
        textoGanaste.text = "";
        setearTextos();
    }
    private void setearTextos()
    {
        textoCantidadRecolectados.text = " Orbes: " + cont.ToString();
        if (cont >= 3)
        {
            textoGanaste.text = " Sobreviviste...  ";
        }

    }
    void Update()
    {
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;
       

        
        movimientoAdelanteAtras *= Time.deltaTime;
       movimientoCostados *= Time.deltaTime;
        

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);
       /* if (Input.GetKeyDown("LeftShift"))
        {
            SprintDesplazamiento *= 20f;

        }
       */

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

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Orbe") == true)
        {

            other.gameObject.SetActive(false);
            cont = cont + 1;
            setearTextos();
        }
    }
    
} 