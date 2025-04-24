using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool inventorytrue;
    public GameObject inventory;//referncia del inventario
    private int allslots;//referncia al numero de slots
    private int enabledslots;//que slots estan disponibles
    private GameObject[] slot;//la lista de los slots para refernciarlos
    public GameObject slotholder;//referncia al contenedor de slots
    void Start()
    {
        allslots = slotholder.transform.childCount;//determina como slot todo lo que este dentro del objeto referenciado como slotholder
        slot = new GameObject[allslots];
        for (int i = 0; i < allslots; i++)//mete en el array "slot" todos los slots creados
        {
            slot[i] = slotholder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slots>().item == null)
            {
                slot[i].GetComponent<Slots>().empty = true;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))//El comando para abrir el inventario
        {
            inventorytrue = !inventorytrue;
        }
        if (inventorytrue)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)//recoge el objeto si el persnaje choca con su collider si tiene la tag Item
    {
        if (other.tag == "Item")
        {
            GameObject itempicked = other.gameObject;
            Item item = itempicked.GetComponent<Item>();
            Additem(itempicked, item.ID, item.type, item.description, item.icon);// El objeto con la tag item debe tener el script item con los diferentes apartados rellenados en el inspector
        }
    }
    public void Additem(GameObject itemobject, int itemID, string itemtype, string itemdescription, Sprite itemicon)//actualiza el slot con la informacion del item recogido
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slot[i].GetComponent<Slots>().empty)
            {
                itemobject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slots>().item = itemobject;
                slot[i].GetComponent<Slots>().ID = itemID;
                slot[i].GetComponent<Slots>().type = itemtype;
                slot[i].GetComponent<Slots>().description = itemdescription;
                slot[i].GetComponent<Slots>().icon = itemicon;

                itemobject.transform.parent = slot[i].transform;
                itemobject.SetActive(false);
                slot[i].GetComponent<Slots>().UpdateSlot();
                slot[i].GetComponent<Slots>().empty = false;
            }
            return;
        }
    }
}
