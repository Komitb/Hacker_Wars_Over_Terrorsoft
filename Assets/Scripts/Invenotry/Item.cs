using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Item : MonoBehaviour
    // este script debe ponerse en los objetos recogibles por el mapa.
    // el objeto debe tener la tag Item
{
    public int ID;//numero del objeto el que sea pero que no se repita
    public string type;//si es un arma u otra herramienta
    public string description;//breve descripcion del objeto
    public Sprite icon;//es la imagen que se vera en el inventario

    [HideInInspector]
    public bool pickedUp;
}