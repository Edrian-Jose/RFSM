using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private bool pickUpAllowed;
    public Item item;

    public Inventory playerInventory;
    void Start()
    {
        item = new Item();
        item.grade.type = ItemType.Consumable;
        item.grade.rarity = (ItemRarity)Random.Range(0, 4);
        Debug.Log(item.grade.rarity);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.Space))
            PickUp();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("collided");
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Collided to player");
            pickUpAllowed = true;
            playerInventory = collision.gameObject.GetComponent<PlayerGFX>().player.GetComponent<Inventory>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("uncollided");
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("unCollided to player");
            pickUpAllowed = false;
        }
    }

    void PickUp()
    {
        playerInventory.AddItem(item);
        Destroy(gameObject);
    }
}
