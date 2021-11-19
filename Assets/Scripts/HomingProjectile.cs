using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : Projectile
{
    protected override void MoveProjectile()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
        
        Vector2 difference = transform.position - targetTransform.transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + 90f);
        
    }
    
   
}
