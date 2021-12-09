using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    public int index;

    public Item item;

    void Start()
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            int oldIndex = eventData.pointerDrag.GetComponent<InventoryItem>().index;
            eventData.pointerDrag.GetComponent<InventoryItem>().index = this.index;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<InventoryItem>().inventory.MoveItem(oldIndex, index);
        }

    }
}
