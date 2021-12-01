using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
     public AIPath aIPath;
    public GameObject enemy;

    void Start(){
        aIPath = enemy.GetComponent<AIPath>();
    }
    void Update()
    {
        float speed = Mathf.Sqrt(Mathf.Pow(aIPath.desiredVelocity.x, 2) + Mathf.Pow(aIPath.desiredVelocity.y, 2));
        
        if (aIPath.desiredVelocity.x <= -0.01f)
        {
            enemy.transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if (aIPath.desiredVelocity.x >= 0.01f){
            enemy.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
