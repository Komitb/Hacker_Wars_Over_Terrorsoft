using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_Controller : MonoBehaviour
{
    public float velocidad = 5f; //Velocidad de Movimiento
    public float opacidad = 1f;
    public  Image ImageUI;
    public Image Suciedad;
    private bool isMousePressed = false; //Para mantener la condición de si el ratón está presionado
    public GameObject VentanaExpandida;
    public GameObject Ventana;
    public GameObject dirtyOver;
    Vector3 lastMousePos;

    // Start is called before the first frame update
    void Start()
    {
        Image ImageUI = GetComponent<Image>();
        Image suciedad = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<<< HEAD:Assets/Scripts/OG/Player_Controler.cs
        Movimineto();
        Arrastrar();
        
        if (isMousePressed && dirtyOver != null && opacidad >= 0.2f)
        {
            // Obtener el ImageUI de dirtyOver
            Image dirtyOverImage = dirtyOver.GetComponent<Image>();
            opacidad = dirtyOverImage.color.a;
            opacidad -= opacidad*Time.deltaTime;
            // Disminuir la opacidad
            dirtyOverImage.color = new Color(dirtyOverImage.color.r, dirtyOverImage.color.g, dirtyOverImage.color.b, opacidad);
            if (opacidad <= 0.2f)
            {
                dirtyOver.SetActive(false);
            }
        }
       
    }
    void Movimineto()
    {
        // Obtener los inputs de las teclas (WASD o las teclas de flechas)
        float horizontal = 0; //Movimiento Izquierda/Derecha
        float vertical = 0; //Movimiento Arriba/Abajo
        if (horizontal == 0)
        {
            vertical = Input.GetAxis("Vertical");
        }
        if (vertical == 0)
        {
            horizontal = Input.GetAxis("Horizontal");
        }
        Vector3 movimiento = new Vector3(horizontal, vertical, 0f) * velocidad * Time.deltaTime;  //Vector de movimiento 
        transform.Translate(movimiento, Space.World); //Movimiento del Personaje
========
        Arrastrar();       
>>>>>>>> main:Assets/Scripts/Window_Controller.cs
    }
    public void Arrastrar() //Hace la funcion de arrastar el raton cuando tienes presionado el boton click izquierdo
    {
        // Mantener presionado el botón izquierdo del ratón
        if (Input.GetMouseButton(0)) // 0 es el botón izquierdo del ratón
        {
            isMousePressed = true;
            if (lastMousePos != Input.mousePosition)
            {
                Debug.Log("El ratón está presionado y se está moviendo. Posición:" + lastMousePos);
                lastMousePos = Input.mousePosition;
            }
        }
        else
        {
            isMousePressed = false;
            opacidad = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Return)) //cunado le des al enter se activara la ventana
        {
            ventana();
        }
<<<<<<<< HEAD:Assets/Scripts/OG/Player_Controler.cs
========
        // Arrastrar y disminuir la opacidad de dirtyOver
        if (isMousePressed && dirtyOver != null && opacidad >= 0.2f)
        {
            // Obtener el ImageUI de dirtyOver
            Image dirtyOverImage = dirtyOver.GetComponent<Image>();
            opacidad = dirtyOverImage.color.a;
            opacidad -= opacidad * Time.deltaTime;
            // Disminuir la opacidad
            dirtyOverImage.color = new Color(dirtyOverImage.color.r, dirtyOverImage.color.g, dirtyOverImage.color.b, opacidad);
            if (opacidad <= 0.2f)
            {
                dirtyOver.SetActive(false);
            }
        }
        else
        {
            isMousePressed = false;
            opacidad = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Return))//cunado le des al enter se activara la ventana
        {
            ventana();
        }
>>>>>>>> main:Assets/Scripts/Window_Controller.cs
    }
    public void Limpiar() // Activa el Arrastrar
    {
        Arrastrar();
    }
    public void GetDirty(GameObject dirty) //Activa la suciedad elegida 
    {
        dirtyOver = dirty;
    }
    public void LoseDirty() //Desaparece la suciedad al terminar de limpiar
    {
        dirtyOver = null;
    }
    public void ventana() //Activa la ventana en mas grande y desactiva el piso 
    {
        Ventana.SetActive(false);
        VentanaExpandida.SetActive(true);
    }
}
