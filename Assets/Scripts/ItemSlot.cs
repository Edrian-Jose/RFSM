using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    public int index;

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
            if (!inventory.items.ContainsKey(index))
            {
                bool equipped = eventData.pointerDrag.GetComponent<InventoryItem>().equipped;
                int oldIndex = eventData.pointerDrag.GetComponent<InventoryItem>().index;
                eventData.pointerDrag.GetComponent<InventoryItem>().index = this.index;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                if (!equipped)
                {
                    eventData.pointerDrag.GetComponent<InventoryItem>().inventory.MoveItem(oldIndex, index);
                }
                else
                {
                    Item droppingItem = eventData.pointerDrag.GetComponent<InventoryItem>().item;
                    eventData.pointerDrag.GetComponent<InventoryItem>().equipped = false;
                    eventData.pointerDrag.GetComponent<InventoryItem>().inventory.RemoveFromGear(droppingItem.slotType, this.index);
                }

            }

        }

    }
}
