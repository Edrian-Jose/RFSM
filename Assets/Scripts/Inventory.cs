using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, Item> items;

    public Dictionary<GearSlot, Item> gear;

    public ItemsManager itemsManager;

    public InventoryBag[] bags;

    public GameObject itemPrefab;
    public Transform[] BagItems;

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

        FillInventorySlot(indexOfItem);
        if (indexOfItem > highestIndex)
        {
            highestIndex = indexOfItem;
        }
        Debug.Log(items[indexOfItem].grade.rarity);
        Debug.Log("Highest Index " + highestIndex);

    }

    public void MoveItem(int from, int to)
    {
        Item aux = new Item();
        bool auxExist = false;
        if (items.ContainsKey(to))
        {
            auxExist = true;
            aux = items[to];
            items.Remove(to);
        }
        items.Add(to, items[from]);
        items.Remove(from);
        PlaceItem(to);

        if (auxExist)
        {
            items.Add(from, aux);
            PlaceItem(from);
        }

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
            FillInventorySlot(index);
        }
    }

    public void FillInventorySlot(int index)
    {
        int bagIndex = index / 20;
        ItemSlot slot = PlaceItem(index);
        GameObject itemObject = Instantiate(itemPrefab, BagItems[bagIndex]);
        itemObject.GetComponent<RectTransform>().anchoredPosition = slot.gameObject.GetComponent<RectTransform>().anchoredPosition;
        itemObject.GetComponent<DragDrop>().canvas = canvas;
        itemObject.GetComponent<InventoryItem>().index = index;
        itemObject.GetComponent<InventoryItem>().inventory = this;
    }

    public ItemSlot PlaceItem(int index)
    {
        Item item = items[index];
        int bagIndex = index / 20;
        int bagSlotIndex = index - (20 * bagIndex);
        InventoryBag bag = bags[bagIndex];
        ItemSlot slot = bag.slots[bagSlotIndex];
        slot.item = item;
        slot.index = index;
        return slot;
    }


    public Sprite GetItemGFX(Item item)
    {
        switch (item.grade.type)
        {
            case ItemType.Weapon:
                return itemsManager.Weapon[item.gfxIndex];
            case ItemType.Armor:
                return itemsManager.Armor[item.gfxIndex];
            case ItemType.Consumable:
                return itemsManager.Consumable[item.gfxIndex];
            default:
                return itemsManager.Consumable[0];
        }
    }
}
