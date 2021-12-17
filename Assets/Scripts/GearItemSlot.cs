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

    public int index;


    void Start()
    {
        index = -1;
    }
    public void OnDrop(PointerEventData eventData)
    {

        Debug.Log("OnDrop on Slot");
        if (eventData.pointerDrag != null)
        {

            int oldIndex = eventData.pointerDrag.GetComponent<InventoryItem>().index;
            var droppingItem = eventData.pointerDrag.GetComponent<InventoryItem>().item;
            if (droppingItem.slotType == gearSlot)
            {
                eventData.pointerDrag.GetComponent<InventoryItem>().index = this.index;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<InventoryItem>().equipped = true;
                eventData.pointerDrag.GetComponent<InventoryItem>().inventory.AddToGear(gearSlot, oldIndex);
            }
        }

    }
}
