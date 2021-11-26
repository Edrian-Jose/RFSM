using System;
using UnityEngine;
using Pathfinding;

class PlayerMovement: MonoBehaviour
{
    PlayerController controller;
    AIPath AI;
    public float range = 0.5f;

    public Player player;
    public GameObject playerTargetGameObject;

    GameObject hitObject = null;
    Vector2? targetWorldPosition;

    // for testing/coding purpose only. to be deleted//
    public Weapon weapon = new Weapon()
    {
        Name = "New weap",
        AtkSpd = 0.5f,
        Range = 1f
    };

    void Start() 
    {
        controller = GetComponent<PlayerController>();

        controller.RightMousePressed += RightMousePressedHandler;
        controller.LeftMousePressed += LeftMousePressedHandler;

        AI = GetComponent<AIPath>();
        player = GetComponent<Player>();
        playerTargetGameObject.transform.position = transform.position;
    }

    void Update()
    {
        Move();
    }

    void RightMousePressedHandler(Vector2 worldPosition, RaycastHit2D hitData)
    {
        if (hitData)
        {
            targetWorldPosition = hitData.transform.position;
            hitObject = hitData.transform.gameObject;
            if(hitObject.transform.tag == "Barricade")
            {
                targetWorldPosition = worldPosition;
            }
        }
        else 
        {
            targetWorldPosition = worldPosition;
            hitObject = null;
        }
        AI.endReachedDistance = range;
    }

    private void LeftMousePressedHandler(Vector2 worldPosition, RaycastHit2D hitData)
    {
       if(hitData && hitData.transform.tag == "Enemy")
       {
           hitObject = hitData.transform.gameObject;
       }
    }


    void Move()
    {
        if (!targetWorldPosition.HasValue)
        {
            return;
        }
        if (hitObject != null)
        {
            if(hitObject.transform.tag == "NPC")
                Debug.Log("Going to NPC");
        }
        playerTargetGameObject.transform.position = GetFootPosition(targetWorldPosition.Value);
    }


    Vector3 GetFootPosition(Vector3 centerPos, float length = 0f)
    {
        return new Vector3(centerPos.x, centerPos.y - length, centerPos.z);
    }

    public void SetTargetPosition (Vector2 position)
    {
        targetWorldPosition = position;
    }

    public void Teleport(int level, int zone)
    {
        if (!ZoneManager.isCurrentScene(level, zone))
        {
            player.scene = new int[2] { level, zone };
            ZoneManager.GoTo(level, zone);
        }
    }
}