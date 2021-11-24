using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, Item> items;

    int highestIndex = 0;

    void Start()
    {
        items = new Dictionary<int, Item>();
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
}
