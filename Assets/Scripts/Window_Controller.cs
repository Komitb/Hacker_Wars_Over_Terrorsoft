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
    private bool isMousePressed = false; //Para mantener la condici�n de si el rat�n est� presionado
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
        Arrastrar();       
    }
    public void Arrastrar() //Hace la funcion de arrastar el raton cuando tienes presionado el boton click izquierdo
    {
        // Mantener presionado el bot�n izquierdo del rat�n
        if (Input.GetMouseButton(0)) // 0 es el bot�n izquierdo del rat�n
        {
            isMousePressed = true;
            if (lastMousePos != Input.mousePosition)
            {
                Debug.Log("El rat�n est� presionado y se est� moviendo. Posici�n:" + lastMousePos);
                lastMousePos = Input.mousePosition;
            }
        }
        else
        {
            isMousePressed = false;
        }
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
