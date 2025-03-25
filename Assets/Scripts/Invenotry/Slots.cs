using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
    //este script lo deben tener todos los slots individualmnete
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;

    public bool empty;// si el slot esta vacio o no
    public Sprite icon;
    public Transform slotIconGameObject;
    private void Start()
    {
        //slotIconGameObject = transform.GetChild(0);
    }
    public void UpdateSlot()//cuando un objeto es recogido se pondra en el slot la imagen puesta en "icon"
    {
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }
}