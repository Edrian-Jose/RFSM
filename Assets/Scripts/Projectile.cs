using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    protected float speed = 5f;
    protected float lifetime = 2f;
    protected float distance = 1f; 
    
    protected Transform targetTransform;

    void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, 0.01f);
        MoveProjectile();
        Debug.DrawRay(transform.position, transform.up, Color.red, 0.5f);
        if(!hitInfo)
        {
            return;
        }
        if(hitInfo.collider.CompareTag("Barricade"))
        {
            DestroyProjectile();
        }
        else if(hitInfo.collider.CompareTag("Enemy"))
        {
            DestroyProjectile();
            //Damage enemy
        }
    }

    protected virtual void MoveProjectile()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }


    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    public  void SetTargetTransform(Transform target)
    {
        targetTransform = target;
    }

    
}
