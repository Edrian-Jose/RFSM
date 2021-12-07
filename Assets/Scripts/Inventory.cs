using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, Item> items;
    public Dictionary<GearSlot, Item> gear;

    public InventoryBag[] bags;

    [SerializeField]
    private Canvas canvas;

    int highestIndex = 0;

    void Start()
    {
        if (canvas)
        {
            canvas.gameObject.SetActive(false);
        }

        items = new Dictionary<int, Item>();
        FillInventory();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            FillInventory();
            canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
        }
    }


    public void AddItem(Item item)
    {
        int indexOfItem = 0;
        for (int i = 0; i <= (highestIndex + 1); i++)
        {
            if (!items.ContainsKey(i))
            {
                items.Add(i, item);
                indexOfItem = i;
                break;
            }
        }

        if (indexOfItem > highestIndex)
        {
            highestIndex = indexOfItem;
        }
        Debug.Log(items[indexOfItem].grade.rarity);
        Debug.Log("Highest Index " + highestIndex);
    }

    public void AddToGear(GearSlot slot, int index)
    {

        Item temp = null;
        if (gear.ContainsKey(slot))
        {
            temp = gear[slot];
        }

        gear[slot] = items[index];

        if (temp != null)
        {
            items[index] = temp;
        }
    }

    public void FillInventory()
    {
        foreach (int index in items.Keys)
        {
            Item item = items[index];
            int bagIndex = index / 20;
            Debug.Log("bagIndex: " + bagIndex);
            int bagSlotIndex = index - (20 * bagIndex);
            InventoryBag bag = bags[bagIndex];
            ItemSlot slot = bag.slots[bagSlotIndex];
            slot.item = item;
            slot.index = index;
            Debug.Log(bagIndex + ", " + bagSlotIndex + ", " + index + ", " + item.grade.rarity);
        }
    }
}
