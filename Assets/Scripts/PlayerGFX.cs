using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class PlayerGFX : MonoBehaviour
{
     public AIPath aIPath;
    public GameObject player;
    Animator playerAnimator;

    void Start(){
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        float speed = Mathf.Sqrt(Mathf.Pow(aIPath.desiredVelocity.x, 2) + Mathf.Pow(aIPath.desiredVelocity.y, 2));

        playerAnimator.SetFloat("Speed", speed);
        
        if (aIPath.desiredVelocity.x <= -0.01f)
        {
            player.transform.localScale = new Vector3(-1f, 1f, 1f);
        }else if (aIPath.desiredVelocity.x >= 0.01f){
            player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
