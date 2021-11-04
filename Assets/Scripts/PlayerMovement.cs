using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject selectedObject;
    public GameObject target;
    public AIPath AI;

    bool AttackMode;
    void Start()
    {
        AI = GetComponent<AIPath>();
        AttackMode = false;
    }
    void Update()
    {
        if (AI.reachedEndOfPath) 
        {
            OnWalkStop();
        }
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);

        Move(worldPosition, hitData);
    }

    void OnWalkStop(){
        Debug.Log("Target Reached");
    }

    void Move(Vector3 worldPosition, RaycastHit2D hitData){
        

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

        }else if(Input.GetMouseButtonDown(1)){
            target.transform.position = worldPosition;
            Debug.Log("Go to that destination");
        }
    }
}

