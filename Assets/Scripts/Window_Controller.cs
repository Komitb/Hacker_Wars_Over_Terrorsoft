using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Window_Controller : MonoBehaviour
{
    public float velocidad = 5f; //Velocidad de Movimiento
    public float opacidad = 1f; //Opacidad acttual de la suciedad
    public int childLeft; //Cantidad de elementos que quedaban por limpiar
    //Referencias de UI
    public Image ImageUI;
    public Image Suciedad;

    private bool isMousePressed = false; //Para mantener la condición de si el ratón está presionado

    //Objetos de la ventana
    public GameObject VentanaExpandida;
    public GameObject Ventana;
    public GameObject dirtyOver;
    public GameObject ChildDirt;
    public int stamina = 10000;
    Vector3 lastMousePos;

    //Estado de la ventana
    public bool ventanaon;
    private bool ventanaTerminada = false;

    //Estos son los controles de los civiles
    public GameObject[] civiles;
    public int civilescount;
    public bool civilRescatado = false;

    //Referencia al player
    Player_Controller player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Player_Controller>(); //Referencia del player
        civilescount = UnityEngine.Random.Range(0, civiles.Length); //Activa un civil aleatorio
        GameObject civil = civiles[civilescount];
        civil.SetActive(true);
        Image ImageUI = GetComponent<Image>(); //Inicializa las referencias
        Image suciedad = GetComponent<Image>();
        foreach (Transform child in VentanaExpandida.GetComponentsInChildren<Transform>()) //Cuenta cuantos hijos se tiene en la ventan expandida
        {
            childLeft++;
        }
        childLeft -= 3; //referencia
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Cuando le das al enter se activará la ventana
        {
            ventana();
        }
        if (stamina >= 1) //Si queda energia nos deja seguir arrastrando
        {
            Arrastrar();
        }
        if (childLeft == 0 && !ventanaTerminada) //Si ya no hay mas elementos por limpiar y no se ha acabado, se cierra la ventana
        {
            ventanaTerminada |= true; //Se asegura para que no se entre mas de una vez
            StartCoroutine(QuitVentana());
        }
    }

    public void Arrastrar() // Hace la función de arrastrar el ratón cuando tienes presionado el botón izquierdo
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
        }

        // Arrastrar y disminuir la opacidad de dirtyOver
        if (isMousePressed && dirtyOver != null && opacidad >= 0.2f)
        {
            // Obtener el ImageUI de dirtyOver
            Image dirtyOverImage = dirtyOver.GetComponent<Image>();

            opacidad = dirtyOverImage.color.a;
            opacidad -= opacidad * Time.deltaTime;
            stamina--;
            // Disminuir la opacidad
            dirtyOverImage.color = new Color(dirtyOverImage.color.r, dirtyOverImage.color.g, dirtyOverImage.color.b, opacidad);

            if (opacidad <= 0.2f && dirtyOver.activeSelf) // Solo se decrementa una vez cuando opacidad llega a 0.2f
            {
                dirtyOver.SetActive(false);
                childLeft--; // Decrementamos childLeft solo una vez
            }
        }
        else
        {
            isMousePressed = false;
            opacidad = 1f;
        }

        /* if (Input.GetKeyDown(KeyCode.Return)) // Cuando le das al enter se activará la ventana
         {
             ventana();
         }*/
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
        ventanaon = true;
    }
    public IEnumerator QuitVentana() //Cierra la ventana al acabar la limpieza y nos activa el civil
    {
        yield return new WaitForSeconds(1);
        if (civilRescatado) yield break; //Esto hace que no se ejecute mas de una vez
        civilRescatado = true;

        //Oculat la ventana que se ha ampliado y muestra la pantalla normal de juego
        VentanaExpandida.SetActive(false);
        Ventana.SetActive(true);
        childLeft = 0;
        ventanaon = false;
        ventanaTerminada = false;

        // Reactiva el movimiento tanto del jugador como del civil
        player.speed = 10f;
        player.civil.gameObject.SetActive(true);
        player.civilOn=true;

        //Añade el timepo extra si se completa el rescate del civil
        TimeManager timeManager = FindAnyObjectByType<TimeManager>();
        if (timeManager != null)
        {
            timeManager.AddTime(10f);
        }
    }
    public void QuitarVentanXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXa() //Llamada para cerrar la ventana
    {
        StartCoroutine(QuitVentana());
    }
}