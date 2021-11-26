using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyCombat : MonoBehaviour
{
    private Transform player;
    private Patrol patrol;

    //For Testing code only//
    private float attackRange = 2f;
    private float attackSpeed = 3f;
    private bool attackReady = true;

    private bool withWeapon = false;

    // Start is called before the first frame update
    void Start()
    {
        patrol = GetComponent<Patrol>();
        //Set here if enemy has weapon or not
    }

    void Update()
    {
        GetPlayer();
        if(CanAttack())
        {
            //If no weapon
            Attack();

            //If with weapon
            //WeaponAttack()
        }
    }

    void WeaponAttack()
    {
        //Check if Ranged or Melee
        //RangedAttack()

        //MeleeAttack()
    }

    bool CanAttack()
    {
        if(player == null)
        {
            return false;
        }
        
        float distanceToPlayer = Vector2.Distance(player.transform.position, this.transform.position);
        return attackRange >= distanceToPlayer && attackReady;
    }

    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(attackSpeed);
        attackReady = true;
    }

    void Attack()
    {
        Debug.Log("Attacking Player");
        attackReady = false;
        StartCoroutine(AttackCoroutine());
    }

    void GetPlayer()
    {
        if(patrol.targets.Length == 1 && patrol.targets[0].tag == "Player")
        {
            player = patrol.targets[0];
        }
    }
}
