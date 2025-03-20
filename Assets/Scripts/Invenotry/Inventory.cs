using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool inventorytrue;
    public GameObject inventory;
    private int allslots;
    private int enabledslots;
    private GameObject[] slot;
    public GameObject slotholder;
    void Start()
    {
        allslots = slotholder.transform.childCount;
        slot = new GameObject[allslots];
        for (int i = 0; i < allslots; i++)
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
        if (Input.GetKeyDown(KeyCode.I))
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            GameObject itempicked = other.gameObject;
            Item item = itempicked.GetComponent<Item>();
            Additem(itempicked, item.ID, item.type, item.description, item.icon);
        }
    }
    public void Additem(GameObject itemobject, int itemID, string itemtype, string itemdescription, Sprite itemicon)
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
