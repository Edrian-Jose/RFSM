using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private bool pickUpAllowed;
    void Start()
    {

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
        }
    }

    void PickUp()
    {
        Destroy(gameObject);
    }
}
