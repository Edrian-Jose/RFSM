using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Image itemImage;
    public Item item;
    public bool equipped;

    public Inventory inventory;

    public int index;
    void Start()
    {
        equipped = false;
        itemImage = GetComponent<Image>();
    }
}
