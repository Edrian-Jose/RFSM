using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Image itemImage;
    Item item;

    public Inventory inventory;

    public int index;
    void Start()
    {
        itemImage = GetComponent<Image>();
    }
}
