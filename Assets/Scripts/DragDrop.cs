using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField]
    public Canvas canvas;
    private CanvasGroup canvasGroup;
    RectTransform rectTransform;
    public Vector2 startPosition;

    public int startIndex;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startPosition = rectTransform.anchoredPosition;
        startIndex = GetComponent<InventoryItem>().index;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.anchoredPosition;
        startIndex = GetComponent<InventoryItem>().index;
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        int endIndex = GetComponent<InventoryItem>().index;

        if (endIndex == startIndex)
        {
            rectTransform.anchoredPosition = startPosition;
        }
        else
        {
            startPosition = rectTransform.anchoredPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {

        bool[] equipped = { eventData.pointerDrag.GetComponent<InventoryItem>().equipped, GetComponent<InventoryItem>().equipped };
        InventoryItem[] items = { eventData.pointerDrag.GetComponent<InventoryItem>(), GetComponent<InventoryItem>() };
        eventData.pointerDrag.GetComponent<InventoryItem>().equipped = equipped[1];
        GetComponent<InventoryItem>().equipped = equipped[0];
        int droppingItemIndex = eventData.pointerDrag.GetComponent<InventoryItem>().index;
        int thisIndex = GetComponent<InventoryItem>().index;

        bool failingDrop = (equipped[0] && equipped[1]) || (equipped[0] && items[1].item.slotType != items[0].item.slotType) || (equipped[1] && items[0].item.slotType != items[1].item.slotType);

        if (failingDrop)
        {
            return;
        }
        if ((!equipped[0] && !equipped[1]))
        {
            eventData.pointerDrag.GetComponent<InventoryItem>().inventory.MoveItem(droppingItemIndex, thisIndex);
            GetComponent<InventoryItem>().inventory.MoveItem(thisIndex, droppingItemIndex);
        }

        if (equipped[0])
        {
            items[1].equipped = true;
            items[0].equipped = false;
            items[1].inventory.AddToGear(items[1].item.slotType, items[1].index);
        }
        if (equipped[1])
        {
            items[0].equipped = true;
            items[1].equipped = false;
            items[0].inventory.AddToGear(items[0].item.slotType, items[0].index);
        }

        var droppingItemPos = eventData.pointerDrag.GetComponent<DragDrop>().startPosition;
        eventData.pointerDrag.GetComponent<InventoryItem>().index = thisIndex;
        GetComponent<InventoryItem>().index = droppingItemIndex;
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        GetComponent<RectTransform>().anchoredPosition = droppingItemPos;
    }

}
