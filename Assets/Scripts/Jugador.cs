using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
     float rapidezDesplazamiento = 15f;
     float velCorrer = 25;
     float velAuxiliar = 15;
    public float staminaTotal = 100f;
    public float staminaRestante;
   
    public Image barra;
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
        staminaRestante = staminaTotal;
        barra.fillAmount = staminaRestante / staminaTotal;
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
        barra.fillAmount = staminaRestante / staminaTotal;
        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;


        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);

        if (staminaRestante <= -0f)
        {

            staminaRestante = 0.0f;

        }
       
        if (staminaRestante >= 100f)
        {
            staminaRestante = 100.0f;
        }

       

            if (Input.GetKey(KeyCode.LeftShift))
            {
                staminaRestante -= Time.deltaTime;
                rapidezDesplazamiento = velCorrer;

            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                staminaRestante += Time.deltaTime;
                rapidezDesplazamiento = velAuxiliar;

            }
        
        

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

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene(0);
        
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