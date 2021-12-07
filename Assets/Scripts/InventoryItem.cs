using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Image itemImage;
    Item item;
    void Start()
    {
        itemImage = GetComponent<Image>();
    }
}
