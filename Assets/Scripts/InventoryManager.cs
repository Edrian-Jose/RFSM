using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryPanel;

    [SerializeField]
    Canvas canvas;

    public bool state;

    void Start()
    {
        inventoryPanel.SetActive(false);
        canvas.gameObject.SetActive(false);
    }


    public void ToggleInventory()
    {
        this.state = !this.state;
        inventoryPanel.SetActive(state);
        canvas.gameObject.SetActive(state);
    }
}
