using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GearItemSlot : MonoBehaviour, IDropHandler
{

    public GearSlot gearSlot;

    public Item item;

    [SerializeField]
    Inventory inventory;

    void Start()
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop on Slot");
        if (eventData.pointerDrag != null)
        {
            if (inventory.gear.ContainsKey(gearSlot))
            {
                //move to inventory
            }

            //place to gear

        }

    }
}
