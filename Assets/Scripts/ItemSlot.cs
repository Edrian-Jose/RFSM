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
                int oldIndex = eventData.pointerDrag.GetComponent<InventoryItem>().index;
                eventData.pointerDrag.GetComponent<InventoryItem>().index = this.index;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<InventoryItem>().inventory.MoveItem(oldIndex, index);
            }

        }

    }
}
