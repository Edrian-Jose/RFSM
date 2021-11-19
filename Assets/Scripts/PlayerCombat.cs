using System;
using System.Collections;
using UnityEngine;

class PlayerCombat: MonoBehaviour
{
    public bool isAttacking = false;
    [SerializeField] private bool aButtonPressed = false;
    [SerializeField] private bool weaponReady = true;
    [SerializeField] private bool autoAttack = false;
    float circleRadius = 15f;
    public LayerMask enemyLayerMask;

    // for testing/coding purpose only. to be deleted//
    public Weapon weapon = new Weapon()
    {
        Name = "New weap",
        AtkSpd = 0.5f,
        Range = 4f
    };

    public GameObject weaponInHand;
    public GameObject projectile;
    public Transform gunPoint;
    public int offset;
    public GameObject target = null;

    /** new **/
    PlayerController controller;
    
    void Start() 
    {
        
        controller = GetComponent<PlayerController>();
        controller.RightMousePressed += RightMousePressedHandler;
        controller.LeftMousePressed += LeftMousePressedHandler;

        controller.AButtonUp += AButtonUpHandler;
    }
    void Update() 
    {
        if (target == null && isAttacking) 
        {
            Collider2D[] enemy = Physics2D.OverlapCircleAll(transform.position, weapon.Range, enemyLayerMask);
            
            if (enemy.Length > 0)
            {
                CheckClosestEnemy(enemy);
                isAttacking = true;
            }
            else
            {
                target = null;
                isAttacking = false;
            }
        }
        
        // Check if there is target
        if(!target)
        {
            return;
        }

        // Check if can attack target
        if(CanAttack() && isAttacking)
        {
            Attack();
        }
    }

    IEnumerator AttackSpeedCoroutine()
    {
        yield return new WaitForSeconds(weapon.AtkSpd);
        weaponReady = true;
    }

    private void Attack()
    {           
        //If ranged
        if(weapon.Range >= 3f)
        {
            RangeAttack();
        }

        //If Melee
        if(weapon.Range < 3f)
        {
            MeleeAttack();
        }     
        weaponReady = false;   
        StartCoroutine(AttackSpeedCoroutine());
    }

    private void RangeAttack()
    {
        //Launch Projectile at Enemy
        HandleWeaponRotation(target.transform, weaponInHand);
        GameObject bullet = Instantiate(projectile, gunPoint.position, weaponInHand.transform.rotation);
        bullet.GetComponent<Projectile>().SetTargetTransform(target.transform);
    }
    
    private void MeleeAttack()
    {
        //Swing weapon
        //target.TakeDamage();
        Debug.Log("Melee Attack!");
    }

    private void HandleWeaponRotation(Transform transform, GameObject weapon)
    {
        Vector2 difference = transform.position - weapon.transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
    }

    private bool CanAttack()
    {
        float distanceToTarget = Vector2.Distance(this.transform.position, target.transform.position);        
        RaycastHit2D hit = Physics2D.Linecast(gunPoint.position, target.transform.position, enemyLayerMask);
        return weapon.Range >= distanceToTarget && weaponReady && (hit.transform.tag == "Enemy");
    }

    private void RightMousePressedHandler(Vector2 worldPosition, RaycastHit2D hitData)
    {
        aButtonPressed = false;
        if (hitData && hitData.transform.tag == "Enemy") 
        {
            target = hitData.transform.gameObject; 
            isAttacking = true;
        }
        else
        {
            target = null;
            isAttacking = false;
        }
        
    }

    private void LeftMousePressedHandler(Vector2 worldPosition, RaycastHit2D hitData)
    {
       if(autoAttack)
       {
            target = (hitData && hitData.transform.tag == "Enemy") 
                    ? hitData.transform.gameObject
                    : null;
            isAttacking = true;
            autoAttack = false;
       }
    }

    private void AButtonUpHandler()
    {
        //aButtonPressed = !aButtonPressed;
        autoAttack = !autoAttack;
    }
    private void CheckClosestEnemy (Collider2D[] enemy)
    {
        float distance = float.MaxValue;
        foreach (Collider2D e in enemy)
        {
            if (e.tag == "Enemy") 
            {
                if (!target) 
                {
                    target = e.transform.gameObject;
                    distance = Vector2.Distance(this.transform.position, e.transform.position);
                } 
                else 
                {
                    float distanceToEnemy = Vector2.Distance(this.transform.position, e.transform.position);
                    if(distanceToEnemy < distance)
                    {
                        distance = distanceToEnemy;
                        target = e.transform.gameObject;
                    }
                }
            }
        }
        
        if (distance == float.MaxValue)
        {
            target = null;
            isAttacking = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, weapon.Range);
    }
}