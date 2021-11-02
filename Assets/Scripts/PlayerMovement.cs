using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject selectedObject;
    bool AttackMode;
    void Start()
    {
        AttackMode = false;
    }
    void Update()
    {
        Move();
    }


    void Move(){
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            AttackMode = true;
        }
        
        if (hitData && AttackMode && Input.GetMouseButtonDown(0))
        {
            AttackMode = false;
            selectedObject = hitData.transform.gameObject;
            Debug.Log("Will Attack enemies");
        }

        if (hitData && Input.GetMouseButtonDown(1))
        {
            AttackMode = false;
            selectedObject = hitData.transform.gameObject;
            if (selectedObject.tag == "Enemy")
            {
                Debug.Log("Attack that enemy");
            }

            if (selectedObject.tag == "NPC")
            {
                Debug.Log("Talk to NPC");
            }

            if (selectedObject.tag == "Destination")
            {
                Debug.Log("Go to that destination");
            }
        }
    }
}

