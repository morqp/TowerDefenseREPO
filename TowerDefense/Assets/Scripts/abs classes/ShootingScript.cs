using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingScript : TargetingScript
{
    //get the bullet prefab and raycast it/instantiate it to the enemy that Shoot picks

    [SerializeField] protected GameObject bulletprefab;


    /*
    protected virtual void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        base.Update();
    }
    */


    public virtual void Shoot()
    {
        if (currentTarget != null && bulletprefab != null)
        {
            GameObject projectile = Instantiate(bulletprefab, transform.position, transform.rotation);

            projectile.GetComponent<BulletScript>().SetTarget(currentTarget);


        }

    }


}
