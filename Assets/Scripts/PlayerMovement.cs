using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerMovement : MonoBehaviour
{

    GameObject selectedObject;
    public GameObject target;
    AIPath AI;
    public float range = 0.5f;

    bool AttackMode;
    void Start()
    {
        AI = GetComponent<AIPath>();
        target.transform.position = transform.position;
        AttackMode = false;
    }
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);
        Move(worldPosition, hitData);
    }

    Vector3 GetFootPosition(Vector3 centerPos, float length = 0.5f){
        return new Vector3(centerPos.x, centerPos.y - length, centerPos.z);
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
                AI.endReachedDistance = range * 3;
                target.transform.position = GetFootPosition(selectedObject.transform.position);
                Debug.Log("Attack that enemy");
            }

            if (selectedObject.tag == "NPC")
            {
                AI.endReachedDistance = range * 2;
                // target.transform.position = GetFootPosition(selectedObject.transform.position);
                // Debug.Log("Talk to NPC");
                ZoneManager.GoTo(1, 1);
            }

        } else if(Input.GetMouseButtonDown(1)){
            AI.endReachedDistance = range;
            target.transform.position = worldPosition;
            Debug.Log("Go to that destination");
        }
    }
}

